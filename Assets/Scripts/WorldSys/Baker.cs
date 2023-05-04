using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    public class Baker : NPC{
        public Baker(string npcName, string npcLocation, float npcXCord, float npcYCord) : base(npcName, npcLocation, BakerProfessionName, new List<string>(), new List<string>() { GoldenBreadName, NormalBreadName, BadBreadName}, npcXCord, npcYCord, 20, 10000, 20){
            generateStartInventory();
            fullWantToBuy();
        }
        private void generateStartInventory(){
            inventory.addProduct(new NormalFlour());
            inventory.addProduct(new NormalFlour());
            inventory.addProduct(new NormalFlour());
        }
        private void fullWantToBuy(){
            ListOfBuyProducts.Add(NormalBreadName);
            ListOfBuyProducts.Add(BadBreadName);
        }
        public override void produceProduct(){
            int prodPlace = inventory.findMinQ(GoldenFlourName, wisdomLevel);
            if(prodPlace != -1){
                inventory.deleteProd(prodPlace);
                inventory.addProduct(new GoldenBread());
            } else{
                prodPlace = inventory.findMinQ(NormalFlourName, wisdomLevel);
                if(prodPlace != -1){
                    inventory.deleteProd(prodPlace);
                    inventory.addProduct(new NormalBread());
                } else{
                    prodPlace = inventory.findMinQ(BadFlourName, wisdomLevel);
                    if(prodPlace != -1){
                        inventory.deleteProd(prodPlace);
                        inventory.addProduct(new BadBread());
                    }
                }
            }
        }
    }
}