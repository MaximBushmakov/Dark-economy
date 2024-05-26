using System;
using System.Collections.Generic;
using static WorldSystem.GlobalNames;
using Newtonsoft.Json.Linq;


namespace WorldSystem
{
    public interface IActivityStrategy
    {
        void DoActivity(NPC npc);
    }

    public class RandomItemProductionStrategy : IActivityStrategy
    {
        private readonly string[] productNames;
        private readonly int[] probabilities;

        public RandomItemProductionStrategy(string[] productNames, int[] probabilities)
        {
            this.productNames = productNames;
            this.probabilities = probabilities;
        }

        public void DoActivity(NPC npc)
        {
            int randNum = npc.rand.Next() % 100;
            int cumulativeProbability = 0;
            for (int i = 0; i < probabilities.Length; i++)
            {
                cumulativeProbability += probabilities[i];
                if (randNum < cumulativeProbability)
                {
                    npc.GetInventory().AddProductType(productNames[i], 1);
                    break;
                }
            }
        }
    }

    public class AddCapitalStrategy : IActivityStrategy
    {
        private readonly int amount;

        public AddCapitalStrategy(int amount)
        {
            this.amount = amount;
        }

        public void DoActivity(NPC npc)
        {
            npc.AddCapital(amount);
        }
    }

    public class AbsorbItemProductionStrategy : IActivityStrategy
    {
        private readonly string[] productNames;
        private readonly string[] materialNames;
        private readonly int[] probabilities;

        public AbsorbItemProductionStrategy(string[] productNames, string[] materialNames, int[] probabilities)
        {
            this.productNames = productNames;
            this.materialNames = materialNames;
            this.probabilities = probabilities;
        }

        public void DoActivity(NPC npc)
        {
            Inventory inventory = npc.GetInventory();
            int prodPlace;
            for (int i = 0; i < probabilities.Length; i++)
            {
                prodPlace = inventory.FindMinQ(materialNames[i], npc.GetWisdomLevel());
                if (prodPlace != -1)
                {
                    inventory.DeleteProd(prodPlace);
                    inventory.AddProductType(productNames[i], 1);
                    break;
                }
            }
        }
    }

    public class TraderStrategy : IActivityStrategy
    {
        private int ticks;
        private int roadPoint;
        private int roadTicks;
        private List<string> roadMap;
        private List<List<string>> tradeMap;

        public TraderStrategy(List<string> roadMap, List<List<string>> tradeMap)
        {
            ticks = 0;
            roadTicks = 0;
            roadPoint = 0;
            this.roadMap = roadMap;
            this.tradeMap = tradeMap;
        }

        public void DoActivity(NPC npc)
        {
            if (roadTicks == 0)
            {
                ChangeLocation(npc);
                NPC tradeNPC = TimeSystem.GetInstance().GetLocation(npc.GetLocation()).FindRandomNPCType(tradeMap[roadPoint][ticks]);
                npc.SetSubLocation(tradeNPC.GetSublocation());
                TimeSystem.GetInstance().WriteLog(npc.GetName() + " торгует с " + tradeNPC.GetProfessionType() + " " + tradeNPC.GetName());
                Prices pricesBuy = tradeNPC.MakePricesSell();
                List<string> npcWantToSell = tradeNPC.GetProduceProduct();
                List<string> npcWantToBuy = tradeNPC.GetMaterial();
                List<Price> ListPrices = pricesBuy.GetPrices();
                int money = 0;
                for (int i = 0; i < ListPrices.Count; ++i)
                {
                    if (npcWantToSell.Contains(ListPrices[i].GetProduct().GetVisibleType(npc.GetWisdomLevel())))
                    {
                        pricesBuy.AddBought(i);
                        npc.GetInventory().AddProduct(ListPrices[i].GetProduct());
                        TimeSystem.GetInstance().WriteLog(npc.GetName() + " покупает " + ListPrices[i].GetProduct().GetSubType());
                        money += ListPrices[i].GetTruePrice();
                    }
                }
                pricesBuy.SetMoney(money);
                tradeNPC.EndSellTrade(pricesBuy);
                //Sell
                Prices pricesSell = tradeNPC.MakePricesBuy(npc.GetInventory());
                ListPrices = pricesSell.GetPrices();
                int moneyNPC = pricesSell.GetMoney();
                money = 0;
                for (int i = ListPrices.Count - 1; i > 0; --i)
                {
                    if (npcWantToBuy.Contains(ListPrices[i].GetProduct().GetVisibleType(npc.GetWisdomLevel())))
                    {
                        if (money + ListPrices[i].GetTruePrice() < moneyNPC)
                        {
                            pricesSell.AddBought(i);
                            npc.GetInventory().DeleteFromInventoryProd(i);
                            TimeSystem.GetInstance().WriteLog(npc.GetName() + " продаёт " + ListPrices[i].GetProduct().GetSubType());
                            money += ListPrices[i].GetTruePrice();
                        }
                    }
                }
                pricesSell.SetMoney(money);
                tradeNPC.EndBuyTrade(pricesSell);
                ++ticks;
            }
        }
        protected void ChangeLocation(NPC npc)
        {
            int luck = 100;
            if (roadTicks > 0)
            {
                --roadTicks;
                if (roadTicks == 0)
                {
                    TimeSystem.GetInstance().WriteLog(npc.GetName() + " прибыл в локацию " + npc.GetLocation());
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
                TimeSystem.GetInstance().TraderChangeLocation(npc, roadMap[roadPoint]);
                roadTicks = RoadData.GetSafeRoadTime(npc.GetLocation(), roadMap[roadPoint]);
                npc.SetLocation(roadMap[roadPoint]);
                npc.SetSubLocation(RoadName);
                DoLocalEvent(AllLocalEvents.GetInstance().GetRandomEvent(luck, RoadName), npc);
                TimeSystem.GetInstance().WriteLog(npc.GetName() + " едет в локацию " + npc.GetLocation());
                ticks = 0;
            }
        }
        public void DoLocalEvent(LocalEvent thisLocalEvent, NPC npc){
            Random rand = new Random();
            TimeSystem.GetInstance().WriteLog(npc.GetName() + " получает событие: " + thisLocalEvent.GetName());
            List<LocalEventEffect> effects = thisLocalEvent.GetEffects();
            for(int i = 0; i < effects.Count; ++i){
                DoLocalEffect(effects[i], npc);
            }
            List<int> answers = thisLocalEvent.GetAnswerId();
            if(answers.Count > 0){
                DoLocalEvent(thisLocalEvent.MakeChose(answers[rand.Next() % answers.Count]), npc);
            }
        }
        public void DoLocalEffect(LocalEventEffect effect, NPC npc){
            switch(effect.GetEffectType()){
                case (KapitalLocalEffectName):
                    npc.AddCapital(effect.GetBaf());
                    break;
                case (ReputationLocalEffectName):
                    break;
                case (MinusProductLocalEffectName):
                    npc.GetInventory().DeleteSomeProduct(effect.GetBaf());
                    break;
                default:
                    npc.GetInventory().AddProductType(effect.GetEffectType(), effect.GetBaf());
                    break;
            }
        }
    }

    public class NPCActivityStrategyFactory
    {
        public IActivityStrategy CreateStrategyFromJson(JObject json)
        {
            string strategyType = json["strategyType"].ToObject<string>();
            switch (strategyType)
        {
            case "RandomItemProduction":
                return new RandomItemProductionStrategy(json["productNames"].ToObject<string[]>(), json["probabilities"].ToObject<int[]>());
            case "AbsorbItemProduction":
                return new AbsorbItemProductionStrategy(json["productNames"].ToObject<string[]>(), json["materialNames"].ToObject<string[]>(), json["probabilities"].ToObject<int[]>());
            case "AddCapital":
                return new AddCapitalStrategy(json["amount"].ToObject<int>());
            case "TraderStrategy":
                return new TraderStrategy(json["roadMap"].ToObject<List<string>>(), json["tradeMap"].ToObject<List<List<string>>>());
            default:
                throw new ArgumentException($"Unknown strategy type: {strategyType}");
        }
        }
    }
}
