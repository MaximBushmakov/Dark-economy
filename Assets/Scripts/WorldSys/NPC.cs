using System;

namespace WorldSystem
{
    class NPC{
        protected string name;
        protected  float xCord;
        protected  float yCord;
        protected Inventory inventory;
        protected Random rand;
        protected int wisdomLevel;
        protected int kapital;
        protected int playerReputation;
        public NPC(string npcName, float npcXCord, float npcYCord, int wisdomlevel, int money, int reputation){
            name = npcName;
            xCord = npcXCord;
            yCord = npcYCord;
            wisdomlevel = wisdomLevel;
            rand = new Random();
            inventory = new Inventory();
            kapital = money;
            playerReputation = reputation;
            TimeSystem.getInstance().addNPCtoTimeSystem(this);
        }
        public string returnName(){
            return name;
        }
        public void proveInventory(){
            List<Product> products = inventory.getInventory();
            for(int i = products.Count() - 1; i >= 0; --i){
                if(products[i].returnQuality() == 0){
                    Console.WriteLine(name + " выкидывает " + products[i].returnSubType());
                    products.RemoveAt(i);
                }
            }
        }
        public virtual void produceProduct(int n){
            int randNum;
            for(int i = 0; i < n; ++i){
                randNum = rand.Next() % 100;
                switch(randNum){
                case > 90:
                    break;
                case > 50:
                    break;
                default:
                    break;
            }
            }
        }
        public void makeTicks(int n){
            proveInventory();
            produceProduct(n);
        }
    }
}