using System;

namespace WorldSystem
{
    class Inventory{
        private List<Product> listOfProducts;
        public Inventory(){
            listOfProducts = new List<Product>();
        }
        public void addProduct(Product newProduct){
            listOfProducts.Add(newProduct);
        }
        public List<Product> getInventory(){
            return listOfProducts;
        }
        public int findMinQ(string type, int wisdom){
            int minQProductPlace = -1;
            int minQProductQuality = 5;
            for(int i = 0; i < listOfProducts.Count(); ++i){
                if(listOfProducts[i].returnType(wisdom) == type){
                    if(listOfProducts[i].returnQuality() < minQProductQuality){
                        minQProductPlace = i;
                        minQProductQuality = listOfProducts[i].returnQuality();
                    }
                }
            }
            return minQProductPlace;
        }
    }
}