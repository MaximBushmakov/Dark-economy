using System;
using System.Collections.Generic;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    public class NPC{
        protected string name;
        protected string location;
        protected string type;
        protected  float xCord;
        protected  float yCord;
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
        public NPC(string npcName, string npcLocation, string npcType, List<String> npcListofProduceMaterial, List<String> npcListofProduceProduct, float npcXCord, float npcYCord, int wisdomlevel, int money, int reputation){
            name = npcName;
            location = npcLocation;
            type = npcType;
            xCord = npcXCord;
            yCord = npcYCord;
            rumor = "Новостей нет";
            wisdomlevel = wisdomLevel;
            rand = new Random();
            inventory = new Inventory();
            kapital = money;
            playerReputation = reputation;
            ListofProduceMaterial = npcListofProduceMaterial;
            ListofProduceProduct = npcListofProduceProduct;
            ListOfEffects = new List<Effect>();
            ListOfBuyProducts = new List<string>();
            DictionaryofPriceEffects = new Dictionary<string, List<Effect>>();
            TimeSystem.getInstance().addNPCtoTimeSystem(this);
            hunger = 10;
        }
        public string getName(){
            return name;
        }
        public int getKapital(){
            return kapital;
        }
        public void reduceKapital(int n){
            kapital -= n;
        }
        public string getType(){
            return type;
        }
        public int getWisdomLevel(){
            return wisdomLevel;
        }
        public List<String> getMaterial(){
            return ListofProduceMaterial;
        }
        public List<String> getProduceProduct(){
            return ListofProduceProduct;
        }
        public void setRumor(string thisrumor){
            rumor = thisrumor;
        }
        public string getRumor(){
            return rumor;
        }
        public void proveInventory(){
            List<Product> products = inventory.getInventory();
            for(int i = products.Count - 1; i >= 0; --i){
                if(products[i].getQuality() == 0){
                    TimeSystem.getInstance().writeLog(name + " выкидывает " + products[i].getSubType());
                    products.RemoveAt(i);
                }
            }
        }
        public void proveEffects(){
            for(int i = ListOfEffects.Count - 1; i >= 0; --i){
                if(ListOfEffects[i].provDone()){
                    TimeSystem.getInstance().writeLog(ListOfEffects[i].getName() + " перестаёт оказывать эффект на " + name);
                    if(ListOfEffects[i].getEffectType() == PriceEffectType){
                        DictionaryofPriceEffects[ListOfEffects[i].getOwner()].Remove(ListOfEffects[i]);
                    }
                    ListOfEffects.RemoveAt(i);
                }
            }
        }
        public virtual void produceProduct(){
            int randNum;
            randNum = rand.Next() % 100;
            switch(randNum){
            case > 90:
                break;
            case > 50:
                break;
            default:
                break;
            }
        }
        public void makeTick(){
            proveInventory();
            proveEffects();
            produceProduct();
            eat();
        }
        public string getLocation(){
            return location;
        }
        public void addEffect(Effect thisEffect){
            ListOfEffects.Add(thisEffect);
            if(thisEffect.getEffectType() == PriceEffectType){
                if(!DictionaryofPriceEffects.ContainsKey(thisEffect.getOwner())){
                    DictionaryofPriceEffects.Add(thisEffect.getOwner(), new List<Effect>());
                }
                DictionaryofPriceEffects[thisEffect.getOwner()].Add(thisEffect);
            }
        }
        public Prices makePricesSell(){
            Prices thisPrices = new Prices();
            List<Product> thisInventory = inventory.getInventory();
            List<Effect> thisEffects;
            string productType;
            Price thisPrice;
            for(int i = 0; i < thisInventory.Count; ++i){
                productType = thisInventory[i].getType(wisdomLevel);
                int tPrice = thisInventory[i].getCost(wisdomLevel);
                if(!ListofProduceMaterial.Contains(productType)){
                    tPrice = tPrice * 2;
                }
                switch (thisInventory[i].getQuality()){
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
                        tPrice = tPrice + tPrice * thisEffects[j].getEffectBaf() / 100;
                    }
                }
                if(DictionaryofPriceEffects.ContainsKey(AllProductsName)){
                    thisEffects = DictionaryofPriceEffects[AllProductsName];
                    for(int j = 0; j < thisEffects.Count; ++j){
                        tPrice = tPrice + tPrice * thisEffects[j].getEffectBaf() / 100;
                    }
                }
                Dictionary<String, List<Effect>> localEffects = TimeSystem.getInstance().getLocation(location).getDictionaryPrice();
                if(localEffects.ContainsKey(productType)){
                    thisEffects = localEffects[productType];
                    for(int j = 0; j < thisEffects.Count; ++j){
                        tPrice = tPrice + tPrice * thisEffects[j].getEffectBaf() / 100;
                    }
                }
                if(localEffects.ContainsKey(AllProductsName)){
                    thisEffects = localEffects[AllProductsName];
                    for(int j = 0; j < thisEffects.Count; ++j){
                        tPrice = tPrice + tPrice * thisEffects[j].getEffectBaf() / 100;
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
                thisPrices.addPrice(thisPrice);
            }
            return thisPrices;
        }
        public Prices makePricesBuy(Inventory sellInventory){
            Prices thisPrices = new Prices();
            thisPrices.setMoney(kapital);
            List<Product> thisInventory = sellInventory.getInventory();
            List<Effect> thisEffects;
            string productType;
            for(int i = 0; i < thisInventory.Count; ++i){
                productType = thisInventory[i].getType(wisdomLevel);
                int tPrice = thisInventory[i].getCost(wisdomLevel);
                if(!ListOfBuyProducts.Contains(productType)){
                    tPrice = tPrice / 10;
                }
                switch (thisInventory[i].getQuality()){
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
                        tPrice = tPrice + tPrice * thisEffects[j].getEffectBaf() / 100;
                    }
                }
                if(DictionaryofPriceEffects.ContainsKey(AllProductsName)){
                    thisEffects = DictionaryofPriceEffects[AllProductsName];
                    for(int j = 0; j < thisEffects.Count; ++j){
                        tPrice = tPrice + tPrice * thisEffects[j].getEffectBaf() / 100;
                    }
                }
                Dictionary<String, List<Effect>> localEffects = TimeSystem.getInstance().getLocation(location).getDictionaryPrice();
                if(localEffects.ContainsKey(productType)){
                    thisEffects = localEffects[productType];
                    for(int j = 0; j < thisEffects.Count; ++j){
                        tPrice = tPrice + tPrice * thisEffects[j].getEffectBaf() / 100;
                    }
                }
                if(localEffects.ContainsKey(AllProductsName)){
                    thisEffects = localEffects[AllProductsName];
                    for(int j = 0; j < thisEffects.Count; ++j){
                        tPrice = tPrice + tPrice * thisEffects[j].getEffectBaf() / 100;
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
                thisPrices.addPrice(thisPrice);
            }
            return thisPrices;
        }
        public void endSellTrade(Prices answerFromTrader){
            kapital += answerFromTrader.getMoney();
            playerReputation += answerFromTrader.getReputationChange();
            List<int> ListOfBought = answerFromTrader.getBought();
            ListOfBought.Sort();
            for(int i = ListOfBought.Count - 1; i > 0; --i){
                inventory.deleteFromInventoryProd(ListOfBought[i]);
            } 
        }
        public void endBuyTrade(Prices answerFromTrader){
            kapital -= answerFromTrader.getMoney();
            playerReputation += answerFromTrader.getReputationChange();
            List<int> ListOfBought = answerFromTrader.getBought();
            ListOfBought.Sort();
            for(int i = ListOfBought.Count - 1; i > 0; --i){
                inventory.addProduct(answerFromTrader.getPrices()[ListOfBought[i]].getProduct());
            } 
        }
        private void eat(){
            if(hunger == 0){
                if(inventory.eatFood(wisdomLevel)){
                    TimeSystem.getInstance().writeLog(name + " поел из запасов.");
                    hunger = 8;
                } else{
                    if(TimeSystem.getInstance().getLocation(location).NPCBuyFood(this)){
                        hunger = 8;
                    } else{
                        TimeSystem.getInstance().writeLog(name + " голоден и не смог купить поесть");
                    }
                }
            } else{
                --hunger; 
            }
        }
        public bool buyFood(NPC NPCbuyer){
            List<Price> prices = makePricesSell().getPrices();
            int NPCkapital = NPCbuyer.getKapital();
            for(int i = 0; i < prices.Count; ++i){
                if(foodNames.Contains(prices[i].getProduct().getType(NPCbuyer.getWisdomLevel())) & prices[i].getTruePrice() < NPCkapital ){
                    TimeSystem.getInstance().writeLog(NPCbuyer.getName() + " купил " + prices[i].getProduct().getSubType() +  " у " + name);
                    NPCbuyer.reduceKapital(prices[i].getTruePrice());
                    inventory.getInventory().RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}