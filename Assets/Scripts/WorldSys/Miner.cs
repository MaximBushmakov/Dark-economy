using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Miner : NPC{
        public Miner(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, MinerProfessionName, new List<string>(), new List<string>() { GoldenMetalName, NormalMetalName, BadMetalName}, ListofSubLocations, 20, 10000, 20){
        }
        protected override void GenerateStartInventory(){
            inventory.AddProduct(new NormalMetal());
            inventory.AddProduct(new NormalMetal());
        }
        public override void DoActivity(){
            int randNum = rand.Next() % 100;
            if(randNum > 65){
                randNum = rand.Next() % 100;
                switch(randNum){
                case > 90:
                    inventory.AddProduct(new GoldenMetal());
                    break;
                case > 50:
                    inventory.AddProduct(new BadMetal());
                    break;
                default:
                    inventory.AddProduct(new NormalMetal());
                    break;
            }
            } else{
                randNum = rand.Next() % 100;
                switch(randNum){
                case > 90:
                    inventory.AddProduct(new GoldenClay());
                    break;
                case > 50:
                    inventory.AddProduct(new BadClay());
                    break;
                default:
                    inventory.AddProduct(new NormalClay());
                    break;
                }
            }
        }
    }
}