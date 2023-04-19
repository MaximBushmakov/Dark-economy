using System;

namespace WorldSystem
{
    class TimeSystem{
        private object threadLock = new object();
        private static TimeSystem instance;
        private List<Product> ListOfProducts;
        private List<NPC> ListOfNPC;
        public void addNPCtoTimeSystem(NPC newNPC){
            lock (threadLock);
            ListOfNPC.Add(newNPC);
            Console.WriteLine(newNPC.returnName() + " now is a part of TimeSystem");
        }
        public void addProducttoTimeSystem(Product newProduct){
            lock (threadLock);
            ListOfProducts.Add(newProduct);
            Console.WriteLine(newProduct.GetType() + " now is a part of TimeSystem");
        }
        public static TimeSystem getInstance(){
            if (instance == null){
                instance = new TimeSystem();
                instance.ListOfNPC = new List<NPC>();
                instance.ListOfProducts = new List<Product>();
            }
            return instance;
        }
        public void makeTicks(int n){
            for(int i = ListOfProducts.Count() - 1; i >= 0; --i){
                ListOfProducts[i].makeTicks(n);
                if(ListOfProducts[i].returnQuality() == 0){
                    Console.WriteLine("TimeSystem отключавет " + ListOfProducts[i].returnSubType());
                    ListOfProducts.RemoveAt(i);
                }
            }
            for(int i = 0; i < ListOfNPC.Count(); ++i){
                ListOfNPC[i].makeTicks(n);
            }
        }
    }
}