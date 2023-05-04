using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    public class Trader: NPC{
        private int ticks;
        private int roadPoint;
        private List<string> roadMap;
        private List<List<string>> tradeMap;
        public Trader(string npcName, List<string> npcRoadMap, List<List<string>> npcTradeMap) : base(npcName, npcRoadMap[0], TraderProfessionName, new List<string>(), new List<string>(), 20, 100, 20){
            ticks = 0;
            roadMap = npcRoadMap;
            tradeMap = npcTradeMap;
        }
        public override void DoActivity(){
            if(ticks >= tradeMap[roadPoint].Count){
                ChangeLocation();
                ticks = 0;
            }
            NPC tradeNPC = TimeSystem.GetInstance().GetLocation(location).FindRandomNPCType(tradeMap[roadPoint][ticks]);
            TimeSystem.GetInstance().WriteLog(name + " торгует с " + tradeNPC.GetProfessionType() + " " + tradeNPC.GetName());
            Prices pricesBuy = tradeNPC.MakePricesSell();
            pricesBuy.AddTraderInventory(inventory);
            List<string> npcWantToSell = tradeNPC.GetProduceProduct();
            List<string> npcWantToBuy = tradeNPC.GetMaterial();
            List<Price> ListPrices = pricesBuy.GetPrices();
            int money = 0;
            for(int i = 0; i < ListPrices.Count; ++i){
                if(npcWantToSell.Contains(ListPrices[i].GetProduct().GetVisibleType(wisdomLevel))){
                    pricesBuy.AddBought(i);
                    inventory.AddProduct(ListPrices[i].GetProduct());
                    TimeSystem.GetInstance().WriteLog(name + " покупает " + ListPrices[i].GetProduct().GetSubType());
                    money += ListPrices[i].GetTruePrice();
                }
            }
            pricesBuy.SetMoney(money);
            tradeNPC.EndSellTrade(pricesBuy);
            //Sell
            Prices pricesSell = tradeNPC.MakePricesBuy(inventory);
            pricesSell.AddTraderInventory(inventory);
            ListPrices = pricesSell.GetPrices();
            int moneyNPC = pricesSell.GetMoney();
            money = 0;
            for(int i = ListPrices.Count - 1; i > 0; --i){
                if(npcWantToBuy.Contains(ListPrices[i].GetProduct().GetVisibleType(wisdomLevel))){
                    if(money + ListPrices[i].GetTruePrice() < moneyNPC){
                        pricesSell.AddBought(i);
                        inventory.DeleteFromInventoryProd(i);
                        TimeSystem.GetInstance().WriteLog(name + " продаёт " + ListPrices[i].GetProduct().GetSubType());
                        money += ListPrices[i].GetTruePrice();
                    }
                }
            }
            pricesSell.SetMoney(money);
            tradeNPC.EndBuyTrade(pricesSell);
            ++ticks;
        }
        public void ChangeLocation(){
            if(roadPoint < roadMap.Count - 1){
                ++roadPoint;
            } else{
                roadPoint = 0;
            }
            TimeSystem.GetInstance().TraderChangeLocation(this, roadMap[roadPoint]);
            location = roadMap[roadPoint];
            TimeSystem.GetInstance().WriteLog(name + " едет в локацию " + location);
        }
    }
}