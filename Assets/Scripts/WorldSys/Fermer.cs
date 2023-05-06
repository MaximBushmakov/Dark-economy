using System;
using System.Collections.Generic;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    [Serializable]
    public class Fermer : NPC
    {
        public Fermer(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, FermerProfessionName, new List<string>(), new List<string>() { GoldenMilletName, NormalMilletName, BadMilletName }, ListofSubLocations, 20, 10000, 20)
        {
        }
        protected override void GenerateStartInventory()
        {
            inventory.AddProduct(new NormalMillet());
            inventory.AddProduct(new NormalMillet());
            inventory.AddProduct(new NormalMillet());
            inventory.AddProduct(new GoldenMillet());
        }
        protected override void FullWantToBuy()
        {
            ListOfBuyProducts.Add(NormalBreadName);
            ListOfBuyProducts.Add(BadBreadName);
        }
        public override void DoActivity()
        {
            int randNum = rand.Next() % 100;
            switch (randNum)
            {
                case > 90:
                    inventory.AddProduct(new GoldenMillet());
                    break;
                case > 50:
                    inventory.AddProduct(new BadMillet());
                    break;
                default:
                    inventory.AddProduct(new NormalMillet());
                    break;
            }
        }
    }
}