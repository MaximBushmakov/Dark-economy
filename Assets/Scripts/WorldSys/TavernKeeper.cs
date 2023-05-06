using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class TavernKeeper : NPC{
        private int roadTicks;
        public TavernKeeper(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, TavernKeeperProfessionName, new List<string>(){NormalBeerName, BadBeerName, GoldenBeerName, NormalDriedMeatName, GoldenDriedMeatName, BadDriedMeatName}, new List<string>() {}, ListofSubLocations, 100, 100000, 20){
        }
        protected override void GenerateStartInventory(){
        }
        protected override void FullWantToBuy(){
        }
        public override void DoActivity(){
            kapital += 10;
        }
    }
}