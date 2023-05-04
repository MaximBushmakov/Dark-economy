using System;
using System.Collections.Generic;

namespace WorldSystem
{
    public class Price{
        private Product product;
        private int truePrice;
        private int viewPrice;
        public Price(Product thisProduct, int thisTruePrice, int thisViewPrice){
            product = thisProduct;
            truePrice = thisTruePrice;
            viewPrice = thisViewPrice;
        }
        public int GetTruePrice(){
            return truePrice;
        }
        public int GetViewPrice(){
            return viewPrice;
        }
        public Product GetProduct(){
            return product;
        }
    }
    public class Prices{
        private List<Price> listOfPrices;
        private List<int> listOfIdBought;
        private Inventory traderInventory;
        private int money;
        private int reputationChage;
        public Prices(){
            listOfPrices = new List<Price>();
            listOfIdBought = new List<int>();
            traderInventory = new Inventory();
            money = 0;
            reputationChage = 0;
        }
        public void SetMoney(int sumOfMoney){
            money = sumOfMoney;
        }
        public int GetMoney(){
            return money;
        }
        public void SetReputationChange(int thisReputationChange){
            reputationChage = thisReputationChange;
        }
        public int GetReputationChange(){
            return reputationChage;
        }
        public void AddPrice(Price price){
            listOfPrices.Add(price);
        }
        public void AddTraderInventory(Inventory thisInventory){
            traderInventory = thisInventory;
        }
        public List<Price> GetPrices(){
            return listOfPrices;
        }
        public void AddBought(int i){
            listOfIdBought.Add(i);
        }
        public List<int> GetBought(){
            return listOfIdBought;
        }
    }
}