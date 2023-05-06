using System;
using System.Collections.Generic;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    [Serializable]
    public class Elder : NPC
    {
        public Elder(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, ElderProfessionName, new List<string>(), new List<string>() { }, ListofSubLocations, 100, 10000, 20)
        {
        }
        protected override void GenerateStartInventory()
        {
            inventory.AddProduct(new NormalBread());
            inventory.AddProduct(new NormalBread());
            inventory.AddProduct(new NormalBread());
            inventory.AddProduct(new NormalBread());
        }
        protected override void FullWantToBuy()
        {
            ListOfBuyProducts.Add(GoldenBreadName);
            ListOfBuyProducts.Add(NormalBreadName);
            ListOfBuyProducts.Add(BadBreadName);
        }
        public override void DoActivity()
        {
            kapital += 10;
        }
    }
}