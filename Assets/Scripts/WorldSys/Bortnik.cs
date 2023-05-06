using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Bortnik : NPC{
        public Bortnik(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, BortnikProfessionName, new List<string>(), new List<string>() { GoldenMilletName, NormalMilletName, BadMilletName}, ListofSubLocations, 20, 10000, 20){
        }
        protected override void GenerateStartInventory(){
            inventory.AddProduct(new NormalHoney());
            inventory.AddProduct(new NormalHoney());
            inventory.AddProduct(new NormalWax());
        }
        protected override void FullWantToBuy(){
            ListOfBuyProducts.Add(NormalBreadName);
            ListOfBuyProducts.Add(BadBreadName);
        }
        public override void DoActivity(){
            int randNum = rand.Next() % 100;
            switch(randNum){
            case > 90:
                inventory.AddProduct(new GoldenWax());
                inventory.AddProduct(new GoldenHoney());
                break;
            case > 50:
                inventory.AddProduct(new BadWax());
                inventory.AddProduct(new BadHoney());
                break;
            default:
                inventory.AddProduct(new NormalWax());
                inventory.AddProduct(new NormalHoney());
                break;
            }
        }
    }
}