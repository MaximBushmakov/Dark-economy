using System;
using System.Collections.Generic;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    [Serializable]
    public class Trader : NPC
    {
        private int ticks;
        private int roadPoint;
        private string sublocation;
        private List<string> roadMap;
        private List<List<string>> tradeMap;
        private int roadTicks;
        private int luck;
        public Trader(string npcName, List<string> npcRoadMap, List<List<string>> npcTradeMap, int thisLuck) : base(npcName, npcRoadMap[0], TraderProfessionName, new List<string>(), new List<string>(), new List<string>(), 20, 100, 20)
        {
            ticks = 0;
            roadMap = npcRoadMap;
            tradeMap = npcTradeMap;
            sublocation = RoadName;
            roadTicks = 0;
            thisLuck = luck;
        }
        public override void DoActivity()
        {
            if (roadTicks == 0)
            {
                NPC tradeNPC = TimeSystem.GetInstance().GetLocation(location).FindRandomNPCType(tradeMap[roadPoint][ticks]);
                sublocation = tradeNPC.GetSublocation();
                TimeSystem.GetInstance().WriteLog(name + " торгует с " + tradeNPC.GetProfessionType() + " " + tradeNPC.GetName());
                Prices pricesBuy = tradeNPC.MakePricesSell();
                List<string> npcWantToSell = tradeNPC.GetProduceProduct();
                List<string> npcWantToBuy = tradeNPC.GetMaterial();
                List<Price> ListPrices = pricesBuy.GetPrices();
                int money = 0;
                for (int i = 0; i < ListPrices.Count; ++i)
                {
                    if (npcWantToSell.Contains(ListPrices[i].GetProduct().GetVisibleType(wisdomLevel)))
                    {
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
                ListPrices = pricesSell.GetPrices();
                int moneyNPC = pricesSell.GetMoney();
                money = 0;
                for (int i = ListPrices.Count - 1; i > 0; --i)
                {
                    if (npcWantToBuy.Contains(ListPrices[i].GetProduct().GetVisibleType(wisdomLevel)))
                    {
                        if (money + ListPrices[i].GetTruePrice() < moneyNPC)
                        {
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
        }
        protected override void ChangeLocation()
        {
            if (roadTicks > 0)
            {
                --roadTicks;
                if (roadTicks == 0)
                {
                    TimeSystem.GetInstance().WriteLog(name + " прибыл в локацию " + location);
                }
            }
            else if (ticks >= tradeMap[roadPoint].Count)
            {
                if (roadPoint < roadMap.Count - 1)
                {
                    ++roadPoint;
                }
                else
                {
                    roadPoint = 0;
                }
                TimeSystem.GetInstance().TraderChangeLocation(this, roadMap[roadPoint]);
                roadTicks = RoadData.GetSafeRoadTime(location, roadMap[roadPoint]);
                location = roadMap[roadPoint];
                sublocation = RoadName;
                DoLocalEvent(AllLocalEvents.GetInstance().GetRandomEvent(luck, RoadName));
                TimeSystem.GetInstance().WriteLog(name + " едет в локацию " + location);
                ticks = 0;
            }
        }
        public void DoLocalEvent(LocalEvent thisLocalEvent){
            TimeSystem.GetInstance().WriteLog(type + " " + name + " получает событие: " + thisLocalEvent.GetName());
            List<LocalEventEffect> effects = thisLocalEvent.GetEffects();
            for(int i = 0; i < effects.Count; ++i){
                DoLocalEffect(effects[i]);
            }
            List<int> answers = thisLocalEvent.GetAnswerId();
            if(answers.Count > 0){
                DoLocalEvent(thisLocalEvent.MakeChose(answers[rand.Next() % answers.Count]));
            }
        }
        public void DoLocalEffect(LocalEventEffect effect){
            switch(effect.GetEffectType()){
                case (KapitalLocalEffectName):
                    kapital += effect.GetBaf();
                    break;
                case (ReputationLocalEffectName):
                    break;
                case (MinusProductLocalEffectName):
                    inventory.DeleteSomeProduct(effect.GetBaf());
                    break;
                default:
                    inventory.AddProductType(effect.GetEffectType(), effect.GetBaf());
                    break;
            }
        }
        public override string GetSublocation(){
            return sublocation;
        }
        protected override void Eat()
        {
            if (roadTicks == 0 & hunger == 0)
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
                    }
                }
            }
            else
            {
                --hunger;
            }
        }
    }
}