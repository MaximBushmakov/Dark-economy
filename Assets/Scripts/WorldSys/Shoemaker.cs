using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Shoemaker : NPC{
        public Shoemaker(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, ShoemakerProfessionName, new List<string>() { GoldenSkinName, NormalSkinName, BadSkinName}, new List<string>() { GoldenShoesName, NormalShoesName, BadShoesName} , ListofSubLocations, 20, 20000, 20){
        }
        protected override void FullWantToBuy(){
            ListOfBuyProducts.Add(NormalBreadName);
            ListOfBuyProducts.Add(NormalSkinName);
            ListOfBuyProducts.Add(GoldenSkinName);
            ListOfBuyProducts.Add(BadSkinName);
        }
        protected override void GenerateStartInventory(){
            inventory.AddProduct(new NormalSkin());
            inventory.AddProduct(new NormalShoes());
        }
        public override void DoActivity(){
            int prodPlace = inventory.FindMinQ(GoldenSkinName, wisdomLevel);
            if(prodPlace != -1){
                inventory.DeleteProd(prodPlace);
                inventory.AddProduct(new GoldenShoes());
            } else{
                prodPlace = inventory.FindMinQ(NormalSkinName, wisdomLevel);
                if(prodPlace != -1){
                    inventory.DeleteProd(prodPlace);
                    inventory.AddProduct(new NormalShoes());
                } else{
                    prodPlace = inventory.FindMinQ(BadSkinName, wisdomLevel);
                    if(prodPlace != -1){
                        inventory.DeleteProd(prodPlace);
                        inventory.AddProduct(new BadShoes());
                    }
                }
            }
        }
    }
}