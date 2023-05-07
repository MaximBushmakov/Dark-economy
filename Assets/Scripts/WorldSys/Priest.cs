using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Priest : NPC{
        public Priest(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, PriestProfessionName, new List<string>() { GoldenWaxName, NormalWaxName, BadWaxName}, new List<string>() { GoldenCandleName, NormalCandleName, BadCandleName, GoldenBookName, NormalBookName, BadBookName} , ListofSubLocations, 20, 20000, 20){
        }
        protected override void GenerateStartInventory(){
            inventory.AddProduct(new NormalMillet());
            inventory.AddProduct(new NormalFlour());
        }
        public override void DoActivity(){
            int randNum = rand.Next() % 100;
            if(randNum > 95){
                randNum = rand.Next() % 100;
                switch(randNum){
                case > 90:
                    inventory.AddProduct(new GoldenBook());
                    break;
                case > 50:
                    inventory.AddProduct(new BadBook());
                    break;
                default:
                    inventory.AddProduct(new NormalBook());
                    break;
                }
            }
            int prodPlace = inventory.FindMinQ(GoldenWaxName, wisdomLevel);
            if(prodPlace != -1){
                inventory.DeleteProd(prodPlace);
                inventory.AddProduct(new GoldenCandle());
            } else{
                prodPlace = inventory.FindMinQ(NormalWaxName, wisdomLevel);
                if(prodPlace != -1){
                    inventory.DeleteProd(prodPlace);
                    inventory.AddProduct(new NormalCandle());
                } else{
                    prodPlace = inventory.FindMinQ(BadWaxName, wisdomLevel);
                    if(prodPlace != -1){
                        inventory.DeleteProd(prodPlace);
                        inventory.AddProduct(new BadCandle());
                    }
                }
            }
        }
    }
}