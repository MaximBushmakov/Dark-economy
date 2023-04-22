using System;
using System.Collections.Generic;

namespace WorldSystem
{
    class TimeSystem{
        private object threadLock = new object();
        private static TimeSystem instance;
        private List<Product> ListOfProducts;
        private List<NPC> ListOfNPC;
        private List<Effect> ListOfEffects;
        private Dictionary<String, Location> DictionaryOfLocations;
        public void addEffecttoTimeSystem(Effect newEffect){
            lock (threadLock);
            ListOfEffects.Add(newEffect);
            Console.WriteLine(newEffect.getName() + " now is a part of TimeSystem");
        }
        public void addNPCtoTimeSystem(NPC newNPC){
            lock (threadLock);
            ListOfNPC.Add(newNPC);
            DictionaryOfLocations[newNPC.getLocation()].addNPC(newNPC);
            Console.WriteLine(newNPC.getName() + " now is a part of TimeSystem");
        }
        public void addProducttoTimeSystem(Product newProduct){
            lock (threadLock);
            ListOfProducts.Add(newProduct);
            Console.WriteLine(newProduct.GetType() + " now is a part of TimeSystem");
        }
        public void addLocationtoTimeSystem(Location location){
            DictionaryOfLocations.Add(location.getName(), location);
        }
        public static TimeSystem getInstance(){
            if (instance == null){
                instance = new TimeSystem();
                instance.ListOfNPC = new List<NPC>();
                instance.ListOfProducts = new List<Product>();
                instance.DictionaryOfLocations = new Dictionary<string, Location>();
                instance.ListOfEffects = new List<Effect>();
            }
            return instance;
        }
        public void makeTicks(int n){
            for(int j = 0; j < n; ++j){
                for(int i = ListOfProducts.Count - 1; i >= 0; --i){
                    ListOfProducts[i].makeTick();
                    if(ListOfProducts[i].getQuality() == 0){
                        Console.WriteLine("TimeSystem отключавет " + ListOfProducts[i].getSubType());
                        ListOfProducts.RemoveAt(i);
                    }
                }
                for(int i = ListOfEffects.Count - 1; i >= 0; --i){
                    ListOfEffects[i].makeTick();
                    if(ListOfEffects[i].provDone()){
                        Console.WriteLine("TimeSystem отключавет " + ListOfEffects[i].getName());
                        ListOfEffects.RemoveAt(i);
                    }
                }
                for(int i = 0; i < ListOfNPC.Count; ++i){
                    ListOfNPC[i].makeTick();
                }
            }
        }
    }
}