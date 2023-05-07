using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Woodworker : NPC{
        public Woodworker(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, WoodworkerProfessionName, new List<string>() { GoldenWoodName, NormalWoodName, BadWoodName}, new List<string>() { GoldenTableName, NormalTableName, BadTableName, GoldenChairName, NormalChairName, BadChairName, GoldenBoardName, NormalBoardName, BadBoardName} , ListofSubLocations, 20, 20000, 20){
        }
        protected override void GenerateStartInventory(){
            inventory.AddProduct(new NormalWood());
            inventory.AddProduct(new NormalWood());
        }
        public override void DoActivity(){
            int prodPlace = inventory.FindMinQ(GoldenWoodName, wisdomLevel);
            if(prodPlace != -1){
                inventory.DeleteProd(prodPlace);
                prodPlace = inventory.FindMinQ(GoldenWoodName, wisdomLevel);
                if(prodPlace != -1){
                    inventory.DeleteProd(prodPlace);
                    prodPlace = inventory.FindMinQ(GoldenWoodName, wisdomLevel);
                    if(prodPlace != -1){
                        inventory.DeleteProd(prodPlace);
                        inventory.AddProduct(new GoldenTable());
                    } else{
                        inventory.AddProduct(new GoldenChair());
                    }
                } else{
                    inventory.AddProduct(new GoldenBoard());
                }
            } else{
                prodPlace = inventory.FindMinQ(NormalWoodName, wisdomLevel);
                if(prodPlace != -1){
                    inventory.DeleteProd(prodPlace);
                    prodPlace = inventory.FindMinQ(NormalWoodName, wisdomLevel);
                    if(prodPlace != -1){
                        inventory.DeleteProd(prodPlace);
                        prodPlace = inventory.FindMinQ(NormalWoodName, wisdomLevel);
                        if(prodPlace != -1){
                            inventory.DeleteProd(prodPlace);
                            inventory.AddProduct(new NormalTable());
                        } else{
                            inventory.AddProduct(new NormalChair());
                        }
                    } else{
                        inventory.AddProduct(new NormalBoard());
                    }
                } else{
                    prodPlace = inventory.FindMinQ(BadWoodName, wisdomLevel);
                    if(prodPlace != -1){
                        inventory.DeleteProd(prodPlace);
                        prodPlace = inventory.FindMinQ(BadWoodName, wisdomLevel);
                        if(prodPlace != -1){
                            inventory.DeleteProd(prodPlace);
                            prodPlace = inventory.FindMinQ(BadWoodName, wisdomLevel);
                            if(prodPlace != -1){
                                inventory.DeleteProd(prodPlace);
                                inventory.AddProduct(new BadTable());
                            } else{
                                inventory.AddProduct(new BadChair());
                            }
                        } else{
                            inventory.AddProduct(new BadBoard());
                        }
                    }
                }
            }
        }
    }
}