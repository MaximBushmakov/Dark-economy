using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Seaman : NPC{
        private int roadTicks;
        public Seaman(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, SeamanProfessionName, new List<string>(){NormalMilletName, GoldenMilletName, BadMilletName, NormalFlourName, GoldenFlourName, BadFlourName, NormalBreadName, GoldenBreadName, BadBreadName, NormalWoodName, GoldenWoodName, BadWoodName, NormalTableName, GoldenTableName, BadTableName, NormalChairName, GoldenChairName, BadChairName, NormalBoardName, GoldenBoardName, BadBoardName}, new List<string>() {}, ListofSubLocations, 100, 100000, 20){
        }
        protected override void GenerateStartInventory(){
        }
        protected override void FullWantToBuy(){
        }
        public override void DoActivity(){
            if (ListofSubLocations[subLocationId] == SeaName){
                SellProducts();
            }
        }
        protected virtual void SellProducts(){
            List<Product> thisProducts = inventory.GetInventory();
            for(int i = 0; i < thisProducts.Count; ++i){
                kapital += thisProducts[i].GetCost(wisdomLevel);
                thisProducts[i].DeleteThis();
            }
            thisProducts.Clear();
        }
    }
}