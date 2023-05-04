using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    class Trader: NPC{
        private int ticks;
        private int roadPoint;
        private List<string> roadMap;
        private List<List<string>> tradeMap;
        public Trader(string npcName, List<string> npcRoadMap, List<List<string>> npcTradeMap, float npcXCord, float npcYCord) : base(npcName, npcRoadMap[0], TraderProfessionName, new List<string>(), new List<string>(), npcXCord, npcYCord, 20, 100, 20){
            ticks = 0;
            roadMap = npcRoadMap;
            tradeMap = npcTradeMap;
        }
        public override void produceProduct(){
            if(ticks >= tradeMap[roadPoint].Count){
                changeLocation();
                ticks = 0;
            }
            NPC tradeNPC = TimeSystem.getInstance().getLocation(location).findRandomNPCType(tradeMap[roadPoint][ticks]);
            TimeSystem.getInstance().writeLog(name + " торгует с " + tradeNPC.getType() + " " + tradeNPC.getName());
            Prices pricesBuy = tradeNPC.makePricesSell();
            pricesBuy.addTraderInventory(inventory);
            List<string> npcWantToSell = tradeNPC.getProduceProduct();
            List<string> npcWantToBuy = tradeNPC.getMaterial();
            List<Price> ListPrices = pricesBuy.getPrices();
            int money = 0;
            for(int i = 0; i < ListPrices.Count; ++i){
                if(npcWantToSell.Contains(ListPrices[i].getProduct().getType(wisdomLevel))){
                    pricesBuy.addBought(i);
                    inventory.addProduct(ListPrices[i].getProduct());
                    TimeSystem.getInstance().writeLog(name + " покупает " + ListPrices[i].getProduct().getSubType());
                    money += ListPrices[i].getTruePrice();
                }
            }
            pricesBuy.setMoney(money);
            tradeNPC.endSellTrade(pricesBuy);
            //Sell
            Prices pricesSell = tradeNPC.makePricesBuy(inventory);
            pricesSell.addTraderInventory(inventory);
            ListPrices = pricesSell.getPrices();
            int moneyNPC = pricesSell.getMoney();
            money = 0;
            for(int i = ListPrices.Count - 1; i > 0; --i){
                if(npcWantToBuy.Contains(ListPrices[i].getProduct().getType(wisdomLevel))){
                    if(money + ListPrices[i].getTruePrice() < moneyNPC){
                        pricesSell.addBought(i);
                        inventory.deleteFromInventoryProd(i);
                        TimeSystem.getInstance().writeLog(name + " продаёт " + ListPrices[i].getProduct().getSubType());
                        money += ListPrices[i].getTruePrice();
                    }
                }
            }
            pricesSell.setMoney(money);
            tradeNPC.endBuyTrade(pricesSell);
            ++ticks;
        }
        public void changeLocation(){
            if(roadPoint < roadMap.Count - 1){
                ++roadPoint;
            } else{
                roadPoint = 0;
            }
            TimeSystem.getInstance().traderChangeLocation(this, roadMap[roadPoint]);
            location = roadMap[roadPoint];
            TimeSystem.getInstance().writeLog(name + " едет в локацию " + location);
        }
    }
}