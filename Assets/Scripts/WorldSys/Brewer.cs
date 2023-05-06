using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Brewer : NPC{
        public Brewer(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, BrewerProfessionName, new List<string>() { GoldenMilletName, NormalMilletName, BadMilletName}, new List<string>() { GoldenBeerName, NormalBeerName, BadBeerName} , ListofSubLocations, 20, 20000, 20){
        }
        protected override void FullWantToBuy(){
            ListOfBuyProducts.Add(NormalBreadName);
            ListOfBuyProducts.Add(NormalMilletName);
            ListOfBuyProducts.Add(GoldenMilletName);
            ListOfBuyProducts.Add(BadMilletName);
        }
        protected override void GenerateStartInventory(){
            inventory.AddProduct(new NormalMillet());
            inventory.AddProduct(new NormalFlour());
        }
        public override void DoActivity(){
            int prodPlace = inventory.FindMinQ(GoldenMilletName, wisdomLevel);
            if(prodPlace != -1){
                inventory.DeleteProd(prodPlace);
                inventory.AddProduct(new GoldenBeer());
            } else{
                prodPlace = inventory.FindMinQ(NormalMilletName, wisdomLevel);
                if(prodPlace != -1){
                    inventory.DeleteProd(prodPlace);
                    inventory.AddProduct(new NormalBeer());
                } else{
                    prodPlace = inventory.FindMinQ(BadMilletName, wisdomLevel);
                    if(prodPlace != -1){
                        inventory.DeleteProd(prodPlace);
                        inventory.AddProduct(new BadBeer());
                    }
                }
            }
        }
    }
}