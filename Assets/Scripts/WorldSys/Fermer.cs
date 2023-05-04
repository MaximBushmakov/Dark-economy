using System;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    class Fermer : NPC{
        public Fermer(string npcName, string npcLocation, float npcXCord, float npcYCord) : base(npcName, npcLocation, FermerProfessionName, new List<string>(), new List<string>() { GoldenMilletName, NormalMilletName, BadMilletName}, npcXCord, npcYCord, 20, 10000, 20){
            generateStartInventory();
            fullWantToBuy();
        }
        private void generateStartInventory(){
            inventory.addProduct(new NormalMillet());
            inventory.addProduct(new NormalMillet());
            inventory.addProduct(new NormalMillet());
            inventory.addProduct(new GoldenMillet());
        }
        private void fullWantToBuy(){
            ListOfBuyProducts.Add(NormalBreadName);
            ListOfBuyProducts.Add(BadBreadName);
        }
        public override void produceProduct(){
            int randNum = rand.Next() % 100;
            switch(randNum){
            case > 90:
                inventory.addProduct(new GoldenMillet());
                break;
            case > 50:
                inventory.addProduct(new BadMillet());
                break;
            default:
                inventory.addProduct(new NormalMillet());
                break;
            }
        }
    }
}