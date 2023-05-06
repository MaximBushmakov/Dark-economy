using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Blacksmith : NPC{
        public Blacksmith(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, BlacksmithProfessionName, new List<string>() { GoldenMetalName, NormalMetalName, BadMetalName}, new List<string>() { GoldenWeaponName, NormalWeaponName, BadWeaponName, GoldenToolName, NormalToolName, BadToolName, GoldenHorseshoeName, NormalHorseshoeName, BadHorseshoeName} , ListofSubLocations, 20, 20000, 20){
        }
        protected override void FullWantToBuy(){
            ListOfBuyProducts.Add(NormalBreadName);
            ListOfBuyProducts.Add(BadBreadName);
            ListOfBuyProducts.Add(NormalWoodName);
            ListOfBuyProducts.Add(GoldenWoodName);
            ListOfBuyProducts.Add(BadWoodName);
        }
        protected override void GenerateStartInventory(){
            inventory.AddProduct(new NormalMetal());
            inventory.AddProduct(new NormalMetal());
        }
        public override void DoActivity(){
            int prodPlace = inventory.FindMinQ(GoldenMetalName, wisdomLevel);
            if(prodPlace != -1){
                inventory.DeleteProd(prodPlace);
                prodPlace = inventory.FindMinQ(GoldenMetalName, wisdomLevel);
                if(prodPlace != -1){
                    inventory.DeleteProd(prodPlace);
                    prodPlace = inventory.FindMinQ(GoldenMetalName, wisdomLevel);
                    if(prodPlace != -1){
                        inventory.DeleteProd(prodPlace);
                        inventory.AddProduct(new GoldenWeapon());
                    } else{
                        inventory.AddProduct(new GoldenTool());
                    }
                } else{
                    inventory.AddProduct(new GoldenHorseshoe());
                }
            } else{
                prodPlace = inventory.FindMinQ(NormalMetalName, wisdomLevel);
                if(prodPlace != -1){
                    inventory.DeleteProd(prodPlace);
                    prodPlace = inventory.FindMinQ(NormalMetalName, wisdomLevel);
                    if(prodPlace != -1){
                        inventory.DeleteProd(prodPlace);
                        prodPlace = inventory.FindMinQ(NormalMetalName, wisdomLevel);
                        if(prodPlace != -1){
                            inventory.DeleteProd(prodPlace);
                            inventory.AddProduct(new NormalWeapon());
                        } else{
                            inventory.AddProduct(new NormalTool());
                        }
                    } else{
                        inventory.AddProduct(new NormalHorseshoe());
                    }
                } else{
                    prodPlace = inventory.FindMinQ(BadMetalName, wisdomLevel);
                    if(prodPlace != -1){
                        inventory.DeleteProd(prodPlace);
                        prodPlace = inventory.FindMinQ(BadMetalName, wisdomLevel);
                        if(prodPlace != -1){
                            inventory.DeleteProd(prodPlace);
                            prodPlace = inventory.FindMinQ(BadMetalName, wisdomLevel);
                            if(prodPlace != -1){
                                inventory.DeleteProd(prodPlace);
                                inventory.AddProduct(new BadWeapon());
                            } else{
                                inventory.AddProduct(new BadTool());
                            }
                        } else{
                            inventory.AddProduct(new BadHorseshoe());
                        }
                    }
                }
            }
        }
    }
}