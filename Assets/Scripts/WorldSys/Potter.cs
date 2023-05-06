using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Potter : NPC{
        public Potter(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, PotterProfessionName, new List<string>() { GoldenClayName, NormalClayName, BadClayName}, new List<string>() { GoldenPotteryName, NormalPotteryName, BadPotteryName} , ListofSubLocations, 20, 20000, 20){
        }
        protected override void FullWantToBuy(){
            ListOfBuyProducts.Add(NormalBreadName);
            ListOfBuyProducts.Add(NormalClayName);
            ListOfBuyProducts.Add(GoldenClayName);
            ListOfBuyProducts.Add(BadClayName);
        }
        protected override void GenerateStartInventory(){
            inventory.AddProduct(new NormalClay());
            inventory.AddProduct(new NormalClay());
        }
        public override void DoActivity(){
            int prodPlace = inventory.FindMinQ(GoldenClayName, wisdomLevel);
            if(prodPlace != -1){
                inventory.DeleteProd(prodPlace);
                inventory.AddProduct(new GoldenPottery());
            } else{
                prodPlace = inventory.FindMinQ(NormalClayName, wisdomLevel);
                if(prodPlace != -1){
                    inventory.DeleteProd(prodPlace);
                    inventory.AddProduct(new NormalPottery());
                } else{
                    prodPlace = inventory.FindMinQ(BadClayName, wisdomLevel);
                    if(prodPlace != -1){
                        inventory.DeleteProd(prodPlace);
                        inventory.AddProduct(new BadPottery());
                    }
                }
            }
        }
    }
}