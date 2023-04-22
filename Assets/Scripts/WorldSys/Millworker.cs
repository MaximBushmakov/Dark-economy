using System;

namespace WorldSystem
{
    class Millworker : NPC{
        public Millworker(string npcName, string npcLocation, float npcXCord, float npcYCord) : base(npcName, npcLocation, npcXCord, npcYCord, 20, 200, 20){
            generateStartInventory();
        }
        private void generateStartInventory(){
            inventory.addProduct(new NormalMillet());
            inventory.addProduct(new NormalFlour());
        }
        public override void produceProduct(){
            int prodPlace = inventory.findMinQ("Золотое Пшено", wisdomLevel);
            if(prodPlace != -1){
                inventory.deleteProd(prodPlace);
                inventory.addProduct(new GoldenFlour());
            } else{
                prodPlace = inventory.findMinQ("Обычное Пшено", wisdomLevel);
                if(prodPlace != -1){
                    inventory.deleteProd(prodPlace);
                    inventory.addProduct(new NormalFlour());
                } else{
                    prodPlace = inventory.findMinQ("Пшено для скота", wisdomLevel);
                    if(prodPlace != -1){
                        inventory.deleteProd(prodPlace);
                        inventory.addProduct(new BadFlour());
                    }
                }
            }
        }
    }
}