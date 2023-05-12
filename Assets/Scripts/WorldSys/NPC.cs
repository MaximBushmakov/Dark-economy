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
        protected Random rand;

        [OnDeserialized]
        private void OnDeserializeMethod(StreamingContext context)
        {
            rand = new Random();
        }

        public List<Effect> GetEffects()
        {
            return ListOfEffects;
        }

        public List<Product> GetInventoryProducts()
        {
            return inventory.GetInventory();
        }

        public NPC(string npcName, string npcLocation, string npcType, List<string> npcListofProduceMaterial, List<string> npcListofProduceProduct, List<string> thisListofSubLocations, int thisWisdomLevel, int money, int reputation)
        {
            name = npcName;
            location = npcLocation;
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
            return ListofSubLocations[subLocationId];
        }
        public int GetKapital()
        {
            return kapital;
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
        public virtual void DoActivity() { }
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
            ++subLocationId;
            if (subLocationId == ListofSubLocations.Count)
            {
                subLocationId = 0;
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
        // Создаёт список цен когда этот НПС продаёт товар
        public Prices MakePricesSell()
        {
            Prices thisPrices = new();
            List<Product> thisInventory = inventory.GetInventory();
            List<Effect> thisEffects;
            string productType;
            Price thisPrice;
            for (int i = 0; i < thisInventory.Count; ++i)
            {
                productType = thisInventory[i].GetVisibleType(wisdomLevel);
                int tPrice = thisInventory[i].GetCost(wisdomLevel);
                if (ListofProduceMaterial.Contains(productType))
                {
                    tPrice +=  tPrice / 10;
                }
                switch (thisInventory[i].GetQuality())
                {
                    case 2:
                        tPrice = tPrice * 8 / 10;
                        break;
                    case 1:
                        tPrice = tPrice * 5 / 10;
                        break;
                    case 0:
                        tPrice = tPrice * 1 / 10;
                        break;
                }
                if (DictionaryofPriceEffects.ContainsKey(productType))
                {
                    thisEffects = DictionaryofPriceEffects[productType];
                    for (int j = 0; j < thisEffects.Count; ++j)
                    {
                        tPrice += tPrice * thisEffects[j].GetEffectBaf() / 100;
                    }
                }
                if (DictionaryofPriceEffects.ContainsKey(AllProductsName))
                {
                    thisEffects = DictionaryofPriceEffects[AllProductsName];
                    for (int j = 0; j < thisEffects.Count; ++j)
                    {
                        tPrice += tPrice * thisEffects[j].GetEffectBaf() / 100;
                    }
                }
                Dictionary<string, List<Effect>> localEffects = TimeSystem.GetInstance().GetLocation(location).GetDictionaryPrice();
                if (localEffects.ContainsKey(productType))
                {
                    thisEffects = localEffects[productType];
                    for (int j = 0; j < thisEffects.Count; ++j)
                    {
                        tPrice += tPrice * thisEffects[j].GetEffectBaf() / 100;
                    }
                }
                if (localEffects.ContainsKey(AllProductsName))
                {
                    thisEffects = localEffects[AllProductsName];
                    for (int j = 0; j < thisEffects.Count; ++j)
                    {
                        tPrice += tPrice * thisEffects[j].GetEffectBaf() / 100;
                    }
                }
                int vPrice = tPrice;
                switch (playerReputation)
                {
                    case < 20:
                        vPrice += vPrice;
                        break;
                    case < 40:
                        vPrice += vPrice / 2;
                        break;
                    case < 70:
                        vPrice += vPrice / 4;
                        break;
                    case < 90:
                        vPrice += vPrice / 10;
                        break;
                }
                thisPrice = new Price(thisInventory[i], tPrice, vPrice);
                thisPrices.AddPrice(thisPrice);
            }
            return thisPrices;
        }
        // Создаёт список цен когда этот НПС покупает товар
        public Prices MakePricesBuy(Inventory sellInventory)
        {
            Prices thisPrices = new();
            thisPrices.SetMoney(kapital);
            List<Product> thisInventory = sellInventory.GetInventory();
            List<Effect> thisEffects;
            string productType;
            for (int i = 0; i < thisInventory.Count; ++i)
            {
                productType = thisInventory[i].GetVisibleType(wisdomLevel);
                int tPrice = thisInventory[i].GetCost(wisdomLevel);
                if (ListOfBuyProducts.Contains(productType))
                {
                    tPrice -= tPrice / 10;
                }
                switch (thisInventory[i].GetQuality())
                {
                    case 2:
                        tPrice = tPrice * 8 / 10;
                        break;
                    case 1:
                        tPrice = tPrice * 5 / 10;
                        break;
                    case 0:
                        tPrice = tPrice * 1 / 10;
                        break;
                }
                if (DictionaryofPriceEffects.ContainsKey(productType))
                {
                    thisEffects = DictionaryofPriceEffects[productType];
                    for (int j = 0; j < thisEffects.Count; ++j)
                    {
                        tPrice += tPrice * thisEffects[j].GetEffectBaf() / 100;
                    }
                }
                if (DictionaryofPriceEffects.ContainsKey(AllProductsName))
                {
                    thisEffects = DictionaryofPriceEffects[AllProductsName];
                    for (int j = 0; j < thisEffects.Count; ++j)
                    {
                        tPrice += tPrice * thisEffects[j].GetEffectBaf() / 100;
                    }
                }
                Dictionary<string, List<Effect>> localEffects = TimeSystem.GetInstance().GetLocation(location).GetDictionaryPrice();
                if (localEffects.ContainsKey(productType))
                {
                    thisEffects = localEffects[productType];
                    for (int j = 0; j < thisEffects.Count; ++j)
                    {
                        tPrice += tPrice * thisEffects[j].GetEffectBaf() / 100;
                    }
                }
                if (localEffects.ContainsKey(AllProductsName))
                {
                    thisEffects = localEffects[AllProductsName];
                    for (int j = 0; j < thisEffects.Count; ++j)
                    {
                        tPrice += tPrice * thisEffects[j].GetEffectBaf() / 100;
                    }
                }
                int vPrice = tPrice;
                switch (playerReputation)
                {
                    case < 20:
                        vPrice -= vPrice;
                        break;
                    case < 40:
                        vPrice -= vPrice / 2;
                        break;
                    case < 70:
                        vPrice -= vPrice / 4;
                        break;
                    case < 90:
                        vPrice -= vPrice / 10;
                        break;
                }
                Price thisPrice = new(thisInventory[i], tPrice, vPrice);
                thisPrices.AddPrice(thisPrice);
            }
            return thisPrices;
        }
        // Конец торговли, когда этот NPC продаёт
        public void EndSellTrade(Prices answerFromTrader)
        {
            kapital += answerFromTrader.GetMoney();
            playerReputation += answerFromTrader.GetReputationChange();
            List<int> ListOfBought = answerFromTrader.GetBought();
            ListOfBought.Sort();
            for (int i = ListOfBought.Count - 1; i >= 0; --i)
            {
                inventory.DeleteFromInventoryProd(ListOfBought[i]);
            }
            ban += answerFromTrader.GetBan();
        }
        // Конец торговли, когда этот NPC покупает
        public void EndBuyTrade(Prices answerFromTrader)
        {
            kapital -= answerFromTrader.GetMoney();
            playerReputation += answerFromTrader.GetReputationChange();
            List<int> ListOfBought = answerFromTrader.GetBought();
            ListOfBought.Sort();
            for (int i = ListOfBought.Count - 1; i >= 0; --i)
            {
                inventory.AddProduct(answerFromTrader.GetPrices()[ListOfBought[i]].GetProduct());
            }
            ban += answerFromTrader.GetBan();
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
            List<Price> prices = MakePricesSell().GetPrices();
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
