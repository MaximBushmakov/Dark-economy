using System;
using System.Collections.Generic;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    [Serializable]
    public class Millworker : NPC
    {
        public Millworker(string npcName, string npcLocation, List<String> ListofSubLocations) : base(npcName, npcLocation, MillworkerProfessionName, new List<string>() { GoldenMilletName, NormalMilletName, BadMilletName }, new List<string>() { GoldenFlourName, NormalFlourName, BadFlourName }, ListofSubLocations, 20, 20000, 20)
        {
        }
        protected override void GenerateStartInventory()
        {
            inventory.AddProduct(new NormalMillet());
            inventory.AddProduct(new NormalFlour());
        }
        public override void DoActivity()
        {
            int prodPlace = inventory.FindMinQ(GoldenMilletName, wisdomLevel);
            if (prodPlace != -1)
            {
                inventory.DeleteProd(prodPlace);
                inventory.AddProduct(new GoldenFlour());
            }
            else
            {
                prodPlace = inventory.FindMinQ(NormalMilletName, wisdomLevel);
                if (prodPlace != -1)
                {
                    inventory.DeleteProd(prodPlace);
                    inventory.AddProduct(new NormalFlour());
                }
                else
                {
                    prodPlace = inventory.FindMinQ(BadMilletName, wisdomLevel);
                    if (prodPlace != -1)
                    {
                        inventory.DeleteProd(prodPlace);
                        inventory.AddProduct(new BadFlour());
                    }
                }
            }
        }
    }
}