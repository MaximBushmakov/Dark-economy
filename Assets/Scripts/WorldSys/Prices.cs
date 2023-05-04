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
        public int getTruePrice(){
            return truePrice;
        }
        public int getViewPrice(){
            return viewPrice;
        }
        public Product getProduct(){
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
        public void setMoney(int sumOfMoney){
            money = sumOfMoney;
        }
        public int getMoney(){
            return money;
        }
        public void setReputationChange(int thisReputationChange){
            reputationChage = thisReputationChange;
        }
        public int getReputationChange(){
            return reputationChage;
        }
        public void addPrice(Price price){
            listOfPrices.Add(price);
        }
        public void addTraderInventory(Inventory thisInventory){
            traderInventory = thisInventory;
        }
        public List<Price> getPrices(){
            return listOfPrices;
        }
        public void addBought(int i){
            listOfIdBought.Add(i);
        }
        public List<int> getBought(){
            return listOfIdBought;
        }
    }
}