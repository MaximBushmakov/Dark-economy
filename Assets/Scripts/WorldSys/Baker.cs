using System;
using System.Collections.Generic;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    [Serializable]
    public class Baker : NPC
    {
        public Baker(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, BakerProfessionName, new List<string>(){GoldenFlourName, NormalFlourName, BadFlourName}, new List<string>() { GoldenBreadName, NormalBreadName, BadBreadName }, ListofSubLocations, 20, 10000, 20)
        {
        }
        protected override void GenerateStartInventory()
        {
            inventory.AddProduct(new NormalFlour());
            inventory.AddProduct(new NormalFlour());
            inventory.AddProduct(new NormalFlour());
        }
        public override void DoActivity()
        {
            int prodPlace = inventory.FindMinQ(GoldenFlourName, wisdomLevel);
            if (prodPlace != -1)
            {
                inventory.DeleteProd(prodPlace);
                inventory.AddProduct(new GoldenBread());
            }
            else
            {
                prodPlace = inventory.FindMinQ(NormalFlourName, wisdomLevel);
                if (prodPlace != -1)
                {
                    inventory.DeleteProd(prodPlace);
                    inventory.AddProduct(new NormalBread());
                }
                else
                {
                    prodPlace = inventory.FindMinQ(BadFlourName, wisdomLevel);
                    if (prodPlace != -1)
                    {
                        inventory.DeleteProd(prodPlace);
                        inventory.AddProduct(new BadBread());
                    }
                }
            }
        }
    }
}