using System;
using System.Collections.Generic;
using static WorldSystem.GlobalNames;
using System.Linq;

namespace WorldSystem
{
    public class NPC{
        protected string name;
        protected string location;
        protected string type;
        protected Inventory inventory;
        protected Random rand;
        protected int wisdomLevel;
        protected int kapital;
        protected int playerReputation;
        protected List<Effect> ListOfEffects;
        protected Dictionary<String, List<Effect>> DictionaryofPriceEffects;
        protected List<String> ListOfBuyProducts;
        protected List<String> ListofProduceMaterial;
        protected List<String> ListofProduceProduct;
        protected string rumor;
        public int hunger;
        public NPC(string npcName, string npcLocation, string npcType, List<String> npcListofProduceMaterial, List<String> npcListofProduceProduct, int thisWisdomLevel, int money, int reputation){
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
        }
        public string GetName(){
            return name;
        }
        public int GetKapital(){
            return kapital;
        }
        public void ReduceKapital(int n){
            kapital -= n;
        }
        public string GetProfessionType(){
            return type;
        }
        public int GetWisdomLevel(){
            return wisdomLevel;
        }
        public List<String> GetMaterial(){
            return ListofProduceMaterial;
        }
        public List<String> GetProduceProduct(){
            return ListofProduceProduct;
        }
        public void SetRumor(string thisrumor){
            rumor = thisrumor;
        }
        public string GetRumor(){
            return rumor;
        }
        public void ProveInventory(){
            List<Product> products = inventory.GetInventory();
            for(int i = products.Count - 1; i >= 0; --i){
                if(products[i].GetQuality() == 0){
                    TimeSystem.GetInstance().WriteLog(name + " выкидывает " + products[i].GetSubType());
                    products.RemoveAt(i);
                }
            }
        }
        public void ProveEffects(){
            for(int i = ListOfEffects.Count - 1; i >= 0; --i){
                if(ListOfEffects[i].ProvDone()){
                    TimeSystem.GetInstance().WriteLog(ListOfEffects[i].GetName() + " перестаёт оказывать эффект на " + name);
                    if(ListOfEffects[i].GetEffectType() == PriceEffectType){
                        DictionaryofPriceEffects[ListOfEffects[i].GetOwner()].Remove(ListOfEffects[i]);
                    }
                    ListOfEffects.RemoveAt(i);
                }
            }
        }
        public virtual void DoActivity(){
        }
        protected virtual void FullWantToBuy(){
        }
        protected virtual void GenerateStartInventory(){
        }
        public void MakeTick(){
            ProveInventory();
            ProveEffects();
            DoActivity();
            Eat();
        }
        public string GetLocation(){
            return location;
        }
        public void AddEffect(Effect thisEffect){
            ListOfEffects.Add(thisEffect);
            if(thisEffect.GetEffectType() == PriceEffectType){
                if(!DictionaryofPriceEffects.ContainsKey(thisEffect.GetOwner())){
                    DictionaryofPriceEffects.Add(thisEffect.GetOwner(), new List<Effect>());
                }
                DictionaryofPriceEffects[thisEffect.GetOwner()].Add(thisEffect);
            }
        }
        public Prices MakePricesSell(){
            Prices thisPrices = new Prices();
            List<Product> thisInventory = inventory.GetInventory();
            List<Effect> thisEffects;
            string productType;
            Price thisPrice;
            for(int i = 0; i < thisInventory.Count; ++i){
                productType = thisInventory[i].GetVisibleType(wisdomLevel);
                int tPrice = thisInventory[i].GetCost(wisdomLevel);
                if(!ListofProduceMaterial.Contains(productType)){
                    tPrice = tPrice * 2;
                }
                switch (thisInventory[i].GetQuality()){
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
                if(DictionaryofPriceEffects.ContainsKey(productType)){
                    thisEffects = DictionaryofPriceEffects[productType];
                    for(int j = 0; j < thisEffects.Count; ++j){
                        tPrice = tPrice + tPrice * thisEffects[j].GetEffectBaf() / 100;
                    }
                }
                if(DictionaryofPriceEffects.ContainsKey(AllProductsName)){
                    thisEffects = DictionaryofPriceEffects[AllProductsName];
                    for(int j = 0; j < thisEffects.Count; ++j){
                        tPrice = tPrice + tPrice * thisEffects[j].GetEffectBaf() / 100;
                    }
                }
                Dictionary<String, List<Effect>> localEffects = TimeSystem.GetInstance().GetLocation(location).GetDictionaryPrice();
                if(localEffects.ContainsKey(productType)){
                    thisEffects = localEffects[productType];
                    for(int j = 0; j < thisEffects.Count; ++j){
                        tPrice = tPrice + tPrice * thisEffects[j].GetEffectBaf() / 100;
                    }
                }
                if(localEffects.ContainsKey(AllProductsName)){
                    thisEffects = localEffects[AllProductsName];
                    for(int j = 0; j < thisEffects.Count; ++j){
                        tPrice = tPrice + tPrice * thisEffects[j].GetEffectBaf() / 100;
                    }
                }
                int vPrice = tPrice;
                switch(playerReputation){
                    case < 20:
                        vPrice = vPrice + vPrice;
                        break;
                    case < 40:
                        vPrice = vPrice + vPrice / 2;
                        break;
                    case < 70:
                        vPrice = vPrice + vPrice / 4;
                        break;
                    case < 90:
                        vPrice = vPrice + vPrice / 10;
                        break;
                }
                thisPrice = new Price(thisInventory[i], tPrice, vPrice);
                thisPrices.AddPrice(thisPrice);
            }
            return thisPrices;
        }
        public Prices MakePricesBuy(Inventory sellInventory){
            Prices thisPrices = new Prices();
            thisPrices.SetMoney(kapital);
            List<Product> thisInventory = sellInventory.GetInventory();
            List<Effect> thisEffects;
            string productType;
            for(int i = 0; i < thisInventory.Count; ++i){
                productType = thisInventory[i].GetVisibleType(wisdomLevel);
                int tPrice = thisInventory[i].GetCost(wisdomLevel);
                if(!ListOfBuyProducts.Contains(productType)){
                    tPrice = tPrice / 10;
                }
                switch (thisInventory[i].GetQuality()){
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
                if(DictionaryofPriceEffects.ContainsKey(productType)){
                    thisEffects = DictionaryofPriceEffects[productType];
                    for(int j = 0; j < thisEffects.Count; ++j){
                        tPrice = tPrice + tPrice * thisEffects[j].GetEffectBaf() / 100;
                    }
                }
                if(DictionaryofPriceEffects.ContainsKey(AllProductsName)){
                    thisEffects = DictionaryofPriceEffects[AllProductsName];
                    for(int j = 0; j < thisEffects.Count; ++j){
                        tPrice = tPrice + tPrice * thisEffects[j].GetEffectBaf() / 100;
                    }
                }
                Dictionary<String, List<Effect>> localEffects = TimeSystem.GetInstance().GetLocation(location).GetDictionaryPrice();
                if(localEffects.ContainsKey(productType)){
                    thisEffects = localEffects[productType];
                    for(int j = 0; j < thisEffects.Count; ++j){
                        tPrice = tPrice + tPrice * thisEffects[j].GetEffectBaf() / 100;
                    }
                }
                if(localEffects.ContainsKey(AllProductsName)){
                    thisEffects = localEffects[AllProductsName];
                    for(int j = 0; j < thisEffects.Count; ++j){
                        tPrice = tPrice + tPrice * thisEffects[j].GetEffectBaf() / 100;
                    }
                }
                int vPrice = tPrice;
                switch(playerReputation){
                    case < 20:
                        vPrice = vPrice + vPrice;
                        break;
                    case < 40:
                        vPrice = vPrice + vPrice / 2;
                        break;
                    case < 70:
                        vPrice = vPrice + vPrice / 4;
                        break;
                    case < 90:
                        vPrice = vPrice + vPrice / 10;
                        break;
                }
                Price thisPrice = new Price(thisInventory[i], tPrice, vPrice);
                thisPrices.AddPrice(thisPrice);
            }
            return thisPrices;
        }
        public void EndSellTrade(Prices answerFromTrader){
            kapital += answerFromTrader.GetMoney();
            playerReputation += answerFromTrader.GetReputationChange();
            List<int> ListOfBought = answerFromTrader.GetBought();
            ListOfBought.Sort();
            for(int i = ListOfBought.Count - 1; i > 0; --i){
                inventory.DeleteFromInventoryProd(ListOfBought[i]);
            } 
        }
        public void EndBuyTrade(Prices answerFromTrader){
            kapital -= answerFromTrader.GetMoney();
            playerReputation += answerFromTrader.GetReputationChange();
            List<int> ListOfBought = answerFromTrader.GetBought();
            ListOfBought.Sort();
            for(int i = ListOfBought.Count - 1; i > 0; --i){
                inventory.AddProduct(answerFromTrader.GetPrices()[ListOfBought[i]].GetProduct());
            } 
        }
        private void Eat(){
            if(hunger == 0){
                if(inventory.EatFood(wisdomLevel)){
                    TimeSystem.GetInstance().WriteLog(name + " поел из запасов.");
                    hunger = 8;
                } else{
                    if(TimeSystem.GetInstance().GetLocation(location).NPCBuyFood(this)){
                        hunger = 8;
                    } else{
                        TimeSystem.GetInstance().WriteLog(name + " голоден и не смог купить поесть");
                    }
                }
            } else{
                --hunger; 
            }
        }
        public bool BuyFood(NPC NPCbuyer){
            List<Price> prices = MakePricesSell().GetPrices();
            int NPCkapital = NPCbuyer.GetKapital();
            for(int i = 0; i < prices.Count; ++i){
                if(foodNames.Contains(prices[i].GetProduct().GetVisibleType(NPCbuyer.GetWisdomLevel())) & prices[i].GetTruePrice() < NPCkapital ){
                    TimeSystem.GetInstance().WriteLog(NPCbuyer.GetName() + " купил " + prices[i].GetProduct().GetSubType() +  " у " + name);
                    NPCbuyer.ReduceKapital(prices[i].GetTruePrice());
                    inventory.GetInventory().RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}