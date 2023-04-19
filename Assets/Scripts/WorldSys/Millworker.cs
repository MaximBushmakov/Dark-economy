using System;

namespace WorldSystem
{
    class Millworker : NPC{
        public Millworker(string npcName, float npcXCord, float npcYCord) : base(npcName, npcXCord, npcYCord, 20, 200, 20){
            generateStartInventory();
        }
        private void generateStartInventory(){
            inventory.addProduct(new NormalMillet());
            inventory.addProduct(new NormalFlour());
        }
        public override void produceProduct(int n){
            int prodPlace;
            for(int i = 0; i < n; ++i){
                prodPlace = inventory.findMinQ("Золотое Пшено", wisdomLevel);
                if(prodPlace != -1){

                } else{
                    prodPlace = inventory.findMinQ("Обычное Пшено", wisdomLevel);
                    if(prodPlace != -1){
                
                    } else{
                        prodPlace = inventory.findMinQ("Пшено для скота", wisdomLevel);
                        if(prodPlace != -1){
                            
                        }
                    }
                }
            }
        }
    }
}