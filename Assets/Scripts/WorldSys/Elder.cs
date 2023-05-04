using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    class Elder : NPC{
        public Elder(string npcName, string npcLocation, float npcXCord, float npcYCord) : base(npcName, npcLocation, ElderProfessionName, new List<string>(), new List<string>() {}, npcXCord, npcYCord, 100, 10000, 20){
            generateStartInventory();
            fullWantToBuy();
        }
        private void generateStartInventory(){
            inventory.addProduct(new NormalBread());
            inventory.addProduct(new NormalBread());
            inventory.addProduct(new NormalBread());
            inventory.addProduct(new NormalBread());
        }
        private void fullWantToBuy(){
            ListOfBuyProducts.Add(GoldenBreadName);
            ListOfBuyProducts.Add(NormalBreadName);
            ListOfBuyProducts.Add(BadBreadName);
        }
        public override void produceProduct(){
            kapital += 10;
        }
    }
}