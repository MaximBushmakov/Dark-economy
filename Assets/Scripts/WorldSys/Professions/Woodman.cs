using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Woodman : NPC{
        public Woodman(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, WoodmanProfessionName, new List<string>(), new List<string>() { GoldenWoodName, NormalWoodName, BadWoodName}, ListofSubLocations, 20, 10000, 20){
        }
        protected override void GenerateStartInventory(){
            inventory.AddProduct(new NormalWood());
            inventory.AddProduct(new NormalWood());
            inventory.AddProduct(new NormalWood());
            inventory.AddProduct(new NormalWood());
        }
        public override void DoActivity(){
            int randNum = rand.Next() % 100;
            switch(randNum){
            case > 90:
                inventory.AddProduct(new GoldenWood());
                break;
            case > 50:
                inventory.AddProduct(new BadWood());
                break;
            default:
                inventory.AddProduct(new NormalWood());
                break;
            }
        }
    }
}