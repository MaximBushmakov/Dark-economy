using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    [Serializable]
    public class TradeController{
        // Создаёт список цен когда этот НПС продаёт товар
        public static Prices MakePricesSell(NPC npc)
        {
            Prices thisPrices = new();
            List<Product> thisInventory = npc.GetInventory().GetInventory();
            List<Effect> thisEffects;
            string productType;
            Price thisPrice;
            Dictionary<string, List<Effect>> DictionaryofPriceEffects = npc.GetDictionaryPrice();
            List<string> ListofProduceMaterial = npc.GetListofProduceMaterial();
            List<string> ListOfBuyProducts = npc.GetListOfBuyProducts();
            List<string> ListofProduceProduct = npc.GetListofProduceProduct();
            for (int i = 0; i < thisInventory.Count; ++i)
            {
                productType = thisInventory[i].GetVisibleType(npc.GetWisdomLevel());
                int tPrice = thisInventory[i].GetCost(npc.GetWisdomLevel());
                if (ListofProduceMaterial.Contains(productType))
                {
                    tPrice += tPrice / 10;
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
                Dictionary<string, List<Effect>> localEffects = TimeSystem.GetInstance().GetLocation(npc.GetLocation()).GetDictionaryPrice();
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
                switch (npc.GetPlayerReputation())
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
        public static Prices MakePricesBuy(NPC npc, Inventory sellInventory)
        {
            Prices thisPrices = new();
            thisPrices.SetMoney(npc.GetKapital());
            List<Product> thisInventory = sellInventory.GetInventory();
            List<Effect> thisEffects;
            string productType;
            Dictionary<string, List<Effect>> DictionaryofPriceEffects = npc.GetDictionaryPrice();
            List<string> ListofProduceMaterial = npc.GetListofProduceMaterial();
            List<string> ListOfBuyProducts = npc.GetListOfBuyProducts();
            List<string> ListofProduceProduct = npc.GetListofProduceProduct();
            for (int i = 0; i < thisInventory.Count; ++i)
            {
                productType = thisInventory[i].GetVisibleType(npc.GetWisdomLevel());
                int tPrice = thisInventory[i].GetCost(npc.GetWisdomLevel());
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
                Dictionary<string, List<Effect>> localEffects = TimeSystem.GetInstance().GetLocation(npc.GetLocation()).GetDictionaryPrice();
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
                switch (npc.GetPlayerReputation())
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
        public static void EndSellTrade(NPC npc, Prices answerFromTrader)
        {
            npc.AddCapital(answerFromTrader.GetMoney());
            npc.AddPlayerReputation(answerFromTrader.GetReputationChange());
            List<int> ListOfBought = answerFromTrader.GetBought();
            ListOfBought.Sort();
            for (int i = ListOfBought.Count - 1; i >= 0; --i)
            {
                npc.GetInventory().DeleteFromInventoryProd(ListOfBought[i]);
            }
            npc.AddBan(answerFromTrader.GetBan());
        }
        // Конец торговли, когда этот NPC покупает
        public static void EndBuyTrade(NPC npc, Prices answerFromTrader)
        {
            npc.AddCapital(answerFromTrader.GetMoney() * -1);
            npc.AddPlayerReputation(answerFromTrader.GetReputationChange());
            List<int> ListOfBought = answerFromTrader.GetBought();
            ListOfBought.Sort();
            for (int i = ListOfBought.Count - 1; i >= 0; --i)
            {
                npc.GetInventory().AddProduct(answerFromTrader.GetPrices()[ListOfBought[i]].GetProduct());
            }
            npc.AddBan(answerFromTrader.GetBan());
        }
    }
}
