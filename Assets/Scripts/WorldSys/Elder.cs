using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    public class Elder : NPC{
        public Elder(string npcName, string npcLocation) : base(npcName, npcLocation, ElderProfessionName, new List<string>(), new List<string>() {}, 100, 10000, 20){
        }
        protected override void GenerateStartInventory(){
            inventory.AddProduct(new NormalBread());
            inventory.AddProduct(new NormalBread());
            inventory.AddProduct(new NormalBread());
            inventory.AddProduct(new NormalBread());
        }
        protected override void FullWantToBuy(){
            ListOfBuyProducts.Add(GoldenBreadName);
            ListOfBuyProducts.Add(NormalBreadName);
            ListOfBuyProducts.Add(BadBreadName);
        }
        public override void DoActivity(){
            kapital += 10;
        }
    }
}