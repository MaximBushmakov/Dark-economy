using System;
using System.Collections.Generic;

namespace WorldSystem
{
    class Price{
        private Product product;
        private int truePrice;
        private int viewPrice;
        public Price(Product thisProduct, int thisTruePrice, int thisViewPrice){
            product = thisProduct;
            truePrice = thisTruePrice;
            viewPrice = thisViewPrice;
        }
    }
    class Prices{
        private List<Price> listOfPrices;
        private List<int> listOfIdBought;
        public Prices(){
            listOfPrices = new List<Price>();
            listOfIdBought = new List<int>();
        }
        public void addPrice(Price price){
            listOfPrices.Add(price);
        }
        public List<Price> getPrices(){
            return listOfPrices;
        }
        public List<int> getBought(){
            return listOfIdBought;
        }
    }
}