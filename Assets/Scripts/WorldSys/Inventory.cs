using System;
using System.Collections.Generic;
using static WorldSystem.GlobalNames;
using System.Linq;

namespace WorldSystem
{
    public class Inventory{
        private List<Product> listOfProducts;
        public Inventory(){
            listOfProducts = new List<Product>();
        }
        public void AddProduct(Product newProduct){
            listOfProducts.Add(newProduct);
        }
        public List<Product> GetInventory(){
            return listOfProducts;
        }
        public int FindMinQ(string type, int wisdom){
            int minQProductPlace = -1;
            int minQProductQuality = 5;
            for(int i = 0; i < listOfProducts.Count; ++i){
                if(listOfProducts[i].GetVisibleType(wisdom) == type){
                    if(listOfProducts[i].GetQuality() < minQProductQuality){
                        minQProductPlace = i;
                        minQProductQuality = listOfProducts[i].GetQuality();
                    }
                }
            }
            return minQProductPlace;
        }
        public void DeleteProd(int i){
            listOfProducts[i].DeleteThis();
            listOfProducts.RemoveAt(i);
        }
        public void DeleteFromInventoryProd(int i){
            listOfProducts.RemoveAt(i);
        }
        public bool EatFood(int wisdom){
            for(int i = 0; i < listOfProducts.Count; ++i){
                if(foodNames.Contains(listOfProducts[i].GetVisibleType(wisdom))){
                    listOfProducts.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}