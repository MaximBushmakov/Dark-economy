using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    [Serializable]
    public class NPC
    {
        protected string name;
        protected string location;
        protected int subLocationId;
        protected string subLocation;
        protected string type;
        protected Inventory inventory;
        protected int wisdomLevel;
        protected int kapital;
        protected int playerReputation;
        protected List<Effect> ListOfEffects;
        protected Dictionary<string, List<Effect>> DictionaryofPriceEffects;
        protected List<string> ListOfBuyProducts;
        protected List<string> ListofProduceMaterial;
        protected List<string> ListofProduceProduct;
        protected List<string> ListofSubLocations;
        protected string rumor;
        protected int hunger;
        protected int ban;
        [field: NonSerialized]
        public Random rand;
        private IActivityStrategy strategy;

        [OnDeserialized]
        private void OnDeserializeMethod(StreamingContext context)
        {
            rand = new Random();
        }

        public List<Effect> GetEffects()
        {
            return ListOfEffects;
        }
        public void SetSubLocation(string subLocation){
            this.subLocation = subLocation;
        }

        public List<Product> GetInventoryProducts()
        {
            return inventory.GetInventory();
        }

        public Inventory GetInventory()
        {
            return inventory;
        }
        public void SetStrategy(IActivityStrategy newStrategy)
        {
            strategy = newStrategy;
        }
        public void SetLocation(string thislocation)
        {
            location = thislocation;
        }
        public NPC(string npcName, string npcLocation, string npcType, List<string> npcListofProduceMaterial, List<string> npcListofProduceProduct, List<string> thisListofSubLocations, int thisWisdomLevel, int money, int reputation)
        {
            name = npcName;
            location = npcLocation;
            subLocation = thisListofSubLocations[0];
            type = npcType;
            rumor = "Новостей нет";
            wisdomLevel = thisWisdomLevel;
            rand = new Random();
            inventory = new Inventory();
            kapital = money;
            playerReputation = reputation;
            ListofProduceMaterial = npcListofProduceMaterial;
            ListofProduceProduct = npcListofProduceProduct;
            ListOfEffects = new List<Effect>();
            ListOfBuyProducts = new List<string>();
            DictionaryofPriceEffects = new Dictionary<string, List<Effect>>();
            TimeSystem.GetInstance().AddNPCtoTimeSystem(this);
            GenerateStartInventory();
            FullWantToBuy();
            hunger = 10;
            ListofSubLocations = thisListofSubLocations;
            subLocationId = 0;
        }
        public int GetPlayerReputation()
        {
            return playerReputation;
        }
        public void AddPlayerReputation(int i)
        {
            playerReputation += i;
        }
        public void AddBan(int i)
        {
            ban += i;
        }
        public Dictionary<string, List<Effect>> GetDictionaryPrice()
        {
            return DictionaryofPriceEffects;
        }
        public List<string> GetListofProduceMaterial()
        {
            return ListofProduceMaterial;
        }
        public List<string> GetListofProduceProduct()
        {
            return ListofProduceProduct;
        }
        public List<string> GetListOfBuyProducts()
        {
            return ListOfBuyProducts;
        }
        public void DoActivity()
        {
            strategy?.DoActivity(this);
        }

        public void AddProductType(string type, int numb){
            this.inventory.AddProductType(type, numb);
        }
        public bool CheckBan()
        {
            return !(ban > 0 || playerReputation < 0);
        }
        public string GetName()
        {
            return name;
        }
        public virtual string GetSublocation()
        {
            if (this.type == "Торговец"){
                return this.subLocation;
            }
            return ListofSubLocations[subLocationId];
        }
        public int GetKapital()
        {
            return kapital;
        }
        public void AddCapital(int i)
        {
            kapital += i;
        }
        public void ReduceKapital(int n)
        {
            kapital -= n;
        }
        public string GetProfessionType()
        {
            return type;
        }
        public int GetWisdomLevel()
        {
            return wisdomLevel;
        }
        public List<string> GetMaterial()
        {
            return ListofProduceMaterial;
        }
        public List<string> GetProduceProduct()
        {
            return ListofProduceProduct;
        }
        public void SetRumor(string thisrumor)
        {
            rumor = thisrumor;
        }
        public string GetRumor()
        {
            return rumor;
        }
        public void ProveInventory()
        {
            List<Product> products = inventory.GetInventory();
            for (int i = products.Count - 1; i >= 0; --i)
            {
                if (products[i].GetQuality() == 0)
                {
                    TimeSystem.GetInstance().WriteLog(type + " " + name + " выкидывает " + products[i].GetSubType());
                    products.RemoveAt(i);
                }
            }
        }
        public void ProveEffects()
        {
            for (int i = ListOfEffects.Count - 1; i >= 0; --i)
            {
                if (ListOfEffects[i].ProvDone())
                {
                    TimeSystem.GetInstance().WriteLog(ListOfEffects[i].GetName() + " перестаёт оказывать эффект на " + type + " " + name);
                    if (ListOfEffects[i].GetEffectType() == PriceEffectType)
                    {
                        DictionaryofPriceEffects[ListOfEffects[i].GetOwner()].Remove(ListOfEffects[i]);
                    }
                    ListOfEffects.RemoveAt(i);
                }
            }
        }
        protected void FullWantToBuy()
        {
            AddFoodProductsToWantBuy();
            for (int i = 0; i < ListofProduceMaterial.Count; ++i)
            {
                ListOfBuyProducts.Add(ListofProduceMaterial[i]);
            }
        }
        protected virtual void GenerateStartInventory() { }
        protected virtual void ChangeLocation()
        {
            if (this.type != "Торговец"){
               ++subLocationId;
                if (subLocationId == ListofSubLocations.Count)
                {
                    subLocationId = 0;
                } 
            }
        }
        public void MakeTick()
        {
            if (ban > 0)
            {
                --ban;
            }
            ChangeLocation();
            ProveInventory();
            ProveEffects();
            DoActivity();
            Eat();
        }
        public string GetLocation()
        {
            return location;
        }
        public void AddEffect(Effect thisEffect)
        {
            ListOfEffects.Add(thisEffect);
            TimeSystem.GetInstance().AddEffecttoTimeSystem(thisEffect);
            if (thisEffect.GetEffectType() == PriceEffectType)
            {
                if (!DictionaryofPriceEffects.ContainsKey(thisEffect.GetOwner()))
                {
                    DictionaryofPriceEffects.Add(thisEffect.GetOwner(), new List<Effect>());
                }
                DictionaryofPriceEffects[thisEffect.GetOwner()].Add(thisEffect);
            }
        }
        protected virtual void Eat()
        {
            if (hunger == 0)
            {
                if (inventory.EatFood(wisdomLevel))
                {
                    TimeSystem.GetInstance().WriteLog(type + " " + name + " поел из запасов.");
                    hunger = 8;
                }
                else
                {
                    if (TimeSystem.GetInstance().GetLocation(location).NPCBuyFood(this))
                    {
                        hunger = 8;
                    }
                    else
                    {
                        TimeSystem.GetInstance().WriteLog(type + " " + name + " голоден и не смог купить поесть");
                        AddEffect(new Effect("Хочет купить хлеб", PriceEffectType, NormalBreadName, 10, 2));
                    }
                }
            }
            else
            {
                --hunger;
            }
        }
        public bool BuyFood(NPC NPCbuyer)
        {
            List<Price> prices = TradeController.MakePricesSell(this).GetPrices();
            int NPCkapital = NPCbuyer.GetKapital();
            for (int i = 0; i < prices.Count; ++i)
            {
                if (foodNames.Contains(prices[i].GetProduct().GetVisibleType(NPCbuyer.GetWisdomLevel())) & prices[i].GetTruePrice() < NPCkapital)
                {
                    TimeSystem.GetInstance().WriteLog(NPCbuyer.GetProfessionType() + " " + NPCbuyer.GetName() + " купил " + prices[i].GetProduct().GetSubType() + " у " + type + " " + name);
                    NPCbuyer.ReduceKapital(prices[i].GetTruePrice());
                    inventory.GetInventory().RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        protected void AddFoodProductsToWantBuy()
        {
            for (int i = 0; i < foodNames.Count(); ++i)
            {
                ListOfBuyProducts.Add(foodNames[i]);
            }
        }
    }
}
