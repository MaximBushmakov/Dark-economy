using System;
using System.Collections.Generic;

namespace WorldSystem
{
    public class Inventory
    {
        private List<Product> listOfProducts;
        public Inventory()
        {
            listOfProducts = new List<Product>();
        }
        public void addProduct(Product newProduct)
        {
            listOfProducts.Add(newProduct);
        }
        public List<Product> getInventory()
        {
            return listOfProducts;
        }
        public int findMinQ(string type, int wisdom)
        {
            int minQProductPlace = -1;
            int minQProductQuality = 5;
            for (int i = 0; i < listOfProducts.Count; ++i)
            {
                if (listOfProducts[i].getType(wisdom) == type)
                {
                    if (listOfProducts[i].getQuality() < minQProductQuality)
                    {
                        minQProductPlace = i;
                        minQProductQuality = listOfProducts[i].getQuality();
                    }
                }
            }
            return minQProductPlace;
        }
        public void deleteProd(int i)
        {
            listOfProducts[i].deleteThis();
            listOfProducts.RemoveAt(i);
        }
    }
}