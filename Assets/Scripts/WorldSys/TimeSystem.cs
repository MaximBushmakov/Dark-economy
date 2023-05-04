using System;
using System.Collections.Generic;
using System.IO;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    public class TimeSystem{
        private object threadLock = new object();
        private static TimeSystem instance;
        private List<Product> ListOfProducts;
        private List<NPC> ListOfNPC;
        private List<Effect> ListOfEffects;
        private Dictionary<String, Location> DictionaryOfLocations;
        private StreamWriter sw;
        private Event currentEvent;
        protected Random rand;
        public void addEffecttoTimeSystem(Effect newEffect){
            lock (threadLock);
            ListOfEffects.Add(newEffect);
            sw.WriteLine(newEffect.getName() + " now is a part of TimeSystem");
        }
        public void addNPCtoTimeSystem(NPC newNPC){
            lock (threadLock);
            ListOfNPC.Add(newNPC);
            DictionaryOfLocations[newNPC.getLocation()].addNPC(newNPC);
            sw.WriteLine(newNPC.getName() + " now is a part of TimeSystem");
        }
        public void addProducttoTimeSystem(Product newProduct){
            lock (threadLock);
            ListOfProducts.Add(newProduct);
            sw.WriteLine(newProduct.getSubType() + " now is a part of TimeSystem");
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
                instance.sw = new StreamWriter("Logs.txt");
                instance.rand = new Random();
            }
            return instance;
        }
        public void writeLog(string text){
            sw.WriteLine(text);
        }
        public void endLog(){
            sw.Close();
        }
        public void startRumors(Event thisevent){
            List<string> ListofRumors = AllEvents.getInstance().getRumors(thisevent, ListOfNPC.Count);
            int randid;
            for(int i = 0; i < ListOfNPC.Count; ++i){
                randid = rand.Next() % ListofRumors.Count;
                ListOfNPC[i].setRumor(ListofRumors[randid]);
                writeLog(ListOfNPC[i].getName() + " получает слух: " + ListOfNPC[i].getRumor());
                ListofRumors.RemoveAt(randid);
            }

        }
        public void startFirstEvent(){
            currentEvent = AllEvents.getInstance().getRandomEvent();
            startRumors(currentEvent);
        }
        public void makeEventStep(){
            if(instance.currentEvent.start()){
                List<Effect> newEffects = currentEvent.getEffects();
                String location = currentEvent.getLocation();
                if(location == AllLocationsName){
                    foreach(var thislocation in DictionaryOfLocations){
                        for(int i = 0; i < newEffects.Count; ++i){
                            thislocation.Value.addEffect(newEffects[i]);
                        }
                    }
                } else{
                    foreach(var thislocation in DictionaryOfLocations){
                        for(int i = 0; i < newEffects.Count; ++i){
                            if(location == thislocation.Key){
                                thislocation.Value.addEffect(newEffects[i]);
                            }
                        }
                    }
                }
                currentEvent = AllEvents.getInstance().getRandomEvent();
                startRumors(currentEvent);
            }
        }
        public void makeTicks(int n){
            for(int j = 0; j < n; ++j){
                makeEventStep();
                foreach(var location in DictionaryOfLocations){
                    location.Value.makeTick();
                }
                for(int i = ListOfProducts.Count - 1; i >= 0; --i){
                    ListOfProducts[i].makeTick();
                    if(ListOfProducts[i].getQuality() == 0){
                        sw.WriteLine("TimeSystem отключавет " + ListOfProducts[i].getSubType());
                        ListOfProducts.RemoveAt(i);
                    }
                }
                for(int i = ListOfEffects.Count - 1; i >= 0; --i){
                    ListOfEffects[i].makeTick();
                    if(ListOfEffects[i].provDone()){
                        sw.WriteLine("TimeSystem отключавет " + ListOfEffects[i].getName());
                        ListOfEffects.RemoveAt(i);
                    }
                }
                for(int i = 0; i < ListOfNPC.Count; ++i){
                    ListOfNPC[i].makeTick();
                }
            }
        }
        public Location getLocation(string nameLocation){
            return DictionaryOfLocations[nameLocation];
        }
        public void traderChangeLocation(NPC thisNPC, string newlocation){
            DictionaryOfLocations[newlocation].deleteNPC(thisNPC);
            DictionaryOfLocations[newlocation].addNPC(thisNPC);
        }
    }
}