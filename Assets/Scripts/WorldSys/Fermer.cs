using System;

namespace WorldSystem
{
    class Fermer : NPC{
        public Fermer(string npcName, float npcXCord, float npcYCord) : base(npcName, npcXCord, npcYCord, 20, 100, 20){
            generateStartInventory();
        }
        private void generateStartInventory(){
            inventory.addProduct(new NormalMillet());
            inventory.addProduct(new NormalMillet());
            inventory.addProduct(new NormalMillet());
            inventory.addProduct(new GoldenMillet());
        }
        public override void produceProduct(int n){
            int randNum;
            for(int i = 0; i < n; ++i){
                randNum = rand.Next() % 100;
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
}