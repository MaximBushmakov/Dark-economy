using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    class Millworker : NPC{
        public Millworker(string npcName, string npcLocation, float npcXCord, float npcYCord) : base(npcName, npcLocation, MillworkerProfessionName, new List<string>() { GoldenMilletName, NormalMilletName, BadMilletName}, new List<string>() { GoldenFlourName, NormalFlourName, BadFlourName} ,npcXCord, npcYCord, 20, 20000, 20){
            generateStartInventory();
            fullWantToBuy();
        }
        private void fullWantToBuy(){
            ListOfBuyProducts.Add(NormalBreadName);
            ListOfBuyProducts.Add(NormalMilletName);
            ListOfBuyProducts.Add(GoldenMilletName);
            ListOfBuyProducts.Add(BadMilletName);
        }
        private void generateStartInventory(){
            inventory.addProduct(new NormalMillet());
            inventory.addProduct(new NormalFlour());
        }
        public override void produceProduct(){
            int prodPlace = inventory.findMinQ(GoldenMilletName, wisdomLevel);
            if(prodPlace != -1){
                inventory.deleteProd(prodPlace);
                inventory.addProduct(new GoldenFlour());
            } else{
                prodPlace = inventory.findMinQ(NormalMilletName, wisdomLevel);
                if(prodPlace != -1){
                    inventory.deleteProd(prodPlace);
                    inventory.addProduct(new NormalFlour());
                } else{
                    prodPlace = inventory.findMinQ(BadMilletName, wisdomLevel);
                    if(prodPlace != -1){
                        inventory.deleteProd(prodPlace);
                        inventory.addProduct(new BadFlour());
                    }
                }
            }
        }
    }
}