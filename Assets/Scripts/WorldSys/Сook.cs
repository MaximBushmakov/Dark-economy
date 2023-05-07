using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Cook : NPC{
        public Cook(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, CookProfessionName, new List<string>() { GoldenMeatName, NormalMeatName, BadMeatName}, new List<string>() { GoldenDriedMeatName, NormalDriedMeatName, BadDriedMeatName} , ListofSubLocations, 20, 20000, 20){
        }
        protected override void GenerateStartInventory(){
            inventory.AddProduct(new NormalDriedMeat());
            inventory.AddProduct(new NormalMeat());
        }
        public override void DoActivity(){
            int prodPlace = inventory.FindMinQ(GoldenMeatName, wisdomLevel);
            if(prodPlace != -1){
                inventory.DeleteProd(prodPlace);
                inventory.AddProduct(new GoldenDriedMeat());
            } else{
                prodPlace = inventory.FindMinQ(NormalMeatName, wisdomLevel);
                if(prodPlace != -1){
                    inventory.DeleteProd(prodPlace);
                    inventory.AddProduct(new NormalDriedMeat());
                } else{
                    prodPlace = inventory.FindMinQ(BadMeatName, wisdomLevel);
                    if(prodPlace != -1){
                        inventory.DeleteProd(prodPlace);
                        inventory.AddProduct(new BadDriedMeat());
                    }
                }
            }
        }
    }
}