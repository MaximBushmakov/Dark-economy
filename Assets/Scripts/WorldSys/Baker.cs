using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    public class Baker : NPC{
        public Baker(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, BakerProfessionName, new List<string>(), new List<string>() { GoldenBreadName, NormalBreadName, BadBreadName}, ListofSubLocations, 20, 10000, 20){
        }
        protected override void GenerateStartInventory(){
            inventory.AddProduct(new NormalFlour());
            inventory.AddProduct(new NormalFlour());
            inventory.AddProduct(new NormalFlour());
        }
        protected override void FullWantToBuy(){
            ListOfBuyProducts.Add(NormalBreadName);
            ListOfBuyProducts.Add(BadBreadName);
        }
        public override void DoActivity(){
            int prodPlace = inventory.FindMinQ(GoldenFlourName, wisdomLevel);
            if(prodPlace != -1){
                inventory.DeleteProd(prodPlace);
                inventory.AddProduct(new GoldenBread());
            } else{
                prodPlace = inventory.FindMinQ(NormalFlourName, wisdomLevel);
                if(prodPlace != -1){
                    inventory.DeleteProd(prodPlace);
                    inventory.AddProduct(new NormalBread());
                } else{
                    prodPlace = inventory.FindMinQ(BadFlourName, wisdomLevel);
                    if(prodPlace != -1){
                        inventory.DeleteProd(prodPlace);
                        inventory.AddProduct(new BadBread());
                    }
                }
            }
        }
    }
}