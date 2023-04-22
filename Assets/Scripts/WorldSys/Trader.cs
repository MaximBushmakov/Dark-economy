using System;

namespace WorldSystem
{
    class Trader: NPC{
        public Trader(string npcName, string npcLocation, float npcXCord, float npcYCord) : base(npcName, npcLocation, npcXCord, npcYCord, 20, 100, 20){
            generateStartInventory();
        }
        private void generateStartInventory(){
            inventory.addProduct(new NormalMillet());
            inventory.addProduct(new NormalMillet());
            inventory.addProduct(new NormalMillet());
            inventory.addProduct(new GoldenMillet());
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