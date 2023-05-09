using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Hunter : NPC{
        public Hunter(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, HunterProfessionName, new List<string>(), new List<string>() { GoldenFurName, NormalFurName, BadFurName, GoldenMeatName, NormalMeatName, BadMeatName, GoldenSkinName, NormalSkinName, BadSkinName}, ListofSubLocations, 20, 10000, 20){
        }
        protected override void GenerateStartInventory(){
            inventory.AddProduct(new NormalMeat());
            inventory.AddProduct(new NormalMeat());
        }
        public override void DoActivity(){
            int randNum = rand.Next() % 100;
            if(randNum > 80){
                randNum = rand.Next() % 100;
                switch(randNum){
                case > 90:
                    inventory.AddProduct(new GoldenFur());
                    break;
                case > 50:
                    inventory.AddProduct(new BadFur());
                    break;
                default:
                    inventory.AddProduct(new NormalFur());
                    break;
            }
            } else{
                randNum = rand.Next() % 100;
                switch(randNum){
                case > 90:
                    inventory.AddProduct(new GoldenMeat());
                    inventory.AddProduct(new GoldenSkin());
                    break;
                case > 50:
                    inventory.AddProduct(new BadMeat());
                    inventory.AddProduct(new BadSkin());
                    break;
                default:
                    inventory.AddProduct(new NormalMeat());
                    inventory.AddProduct(new NormalSkin());
                    break;
                }
            }
        }
    }
}