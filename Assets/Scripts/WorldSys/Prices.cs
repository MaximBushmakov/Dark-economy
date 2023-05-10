using System;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Price
    {
        private Product product;
        private int truePrice;
        private int viewPrice;
        public Price(Product thisProduct, int thisTruePrice, int thisViewPrice)
        {
            product = thisProduct;
            truePrice = thisTruePrice;
            viewPrice = thisViewPrice;
        }
        public int GetTruePrice()
        {
            return truePrice;
        }
        public int GetViewPrice()
        {
            return viewPrice;
        }
        public Product GetProduct()
        {
            return product;
        }
    }
    public class Prices
    {
        // список цен
        private List<Price> listOfPrices;
        // Список id купленных товаров в списке цен
        private List<int> listOfIdBought;
        // 
        private Inventory traderInventory;
        // деньги которые получает или отдаёт NPC
        private int money;
        // изменение репутации при торговле
        private int reputationChage;
        // отказ от торговли на время
        private int ban;
        public Prices()
        {
            listOfPrices = new List<Price>();
            listOfIdBought = new List<int>();
            traderInventory = new Inventory();
            money = 0;
            reputationChage = 0;
            ban = 0;
        }
        public void SetMoney(int sumOfMoney)
        {
            money = sumOfMoney;
        }
        public int GetMoney()
        {
            return money;
        }
        public void SetBan(int thisBan)
        {
            ban = thisBan;
        }
        public int GetBan()
        {
            return ban;
        }
        public void SetReputationChange(int thisReputationChange)
        {
            reputationChage = thisReputationChange;
        }
        public int GetReputationChange()
        {
            return reputationChage;
        }
        public void AddPrice(Price price)
        {
            listOfPrices.Add(price);
        }
        public void AddTraderInventory(Inventory thisInventory)
        {
            traderInventory = thisInventory;
        }
        public List<Price> GetPrices()
        {
            return listOfPrices;
        }
        public void AddBought(int i)
        {
            listOfIdBought.Add(i);
        }
        public List<int> GetBought()
        {
            return listOfIdBought;
        }
    }
}