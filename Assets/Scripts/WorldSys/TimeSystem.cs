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
        public void AddEffecttoTimeSystem(Effect newEffect){
            lock (threadLock);
            ListOfEffects.Add(newEffect);
            sw.WriteLine(newEffect.GetName() + " now is a part of TimeSystem");
        }
        public void AddNPCtoTimeSystem(NPC newNPC){
            lock (threadLock);
            ListOfNPC.Add(newNPC);
            DictionaryOfLocations[newNPC.GetLocation()].AddNPC(newNPC);
            sw.WriteLine(newNPC.GetName() + " now is a part of TimeSystem");
        }
        public void AddProducttoTimeSystem(Product newProduct){
            lock (threadLock);
            ListOfProducts.Add(newProduct);
            sw.WriteLine(newProduct.GetSubType() + " now is a part of TimeSystem");
        }
        public void AddLocationtoTimeSystem(Location location){
            DictionaryOfLocations.Add(location.GetName(), location);
        }
        public static TimeSystem GetInstance(){
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
        public void WriteLog(string text){
            sw.WriteLine(text);
        }
        public void EndLog(){
            sw.Close();
        }
        public void StartRumors(Event thisevent){
            List<string> ListofRumors = AllEvents.GetInstance().GetRumors(thisevent, ListOfNPC.Count);
            int randid;
            for(int i = 0; i < ListOfNPC.Count; ++i){
                randid = rand.Next() % ListofRumors.Count;
                ListOfNPC[i].SetRumor(ListofRumors[randid]);
                WriteLog(ListOfNPC[i].GetName() + " получает слух: " + ListOfNPC[i].GetRumor());
                ListofRumors.RemoveAt(randid);
            }

        }
        public void StartFirstEvent(){
            currentEvent = AllEvents.GetInstance().GetRandomEvent();
            StartRumors(currentEvent);
        }
        public void MakeEventStep(){
            if(instance.currentEvent.Start()){
                List<Effect> newEffects = currentEvent.GetEffects();
                String location = currentEvent.GetLocation();
                if(location == AllLocationsName){
                    foreach(var thislocation in DictionaryOfLocations){
                        for(int i = 0; i < newEffects.Count; ++i){
                            thislocation.Value.AddEffect(newEffects[i]);
                        }
                    }
                } else{
                    foreach(var thislocation in DictionaryOfLocations){
                        for(int i = 0; i < newEffects.Count; ++i){
                            if(location == thislocation.Key){
                                thislocation.Value.AddEffect(newEffects[i]);
                            }
                        }
                    }
                }
                currentEvent = AllEvents.GetInstance().GetRandomEvent();
                StartRumors(currentEvent);
            }
        }
        public void MakeTicks(int n){
            for(int j = 0; j < n; ++j){
                MakeEventStep();
                foreach(var location in DictionaryOfLocations){
                    location.Value.MakeTick();
                }
                for(int i = ListOfProducts.Count - 1; i >= 0; --i){
                    ListOfProducts[i].MakeTick();
                    if(ListOfProducts[i].GetQuality() == 0){
                        sw.WriteLine("TimeSystem отключавет " + ListOfProducts[i].GetSubType());
                        ListOfProducts.RemoveAt(i);
                    }
                }
                for(int i = ListOfEffects.Count - 1; i >= 0; --i){
                    ListOfEffects[i].MakeTick();
                    if(ListOfEffects[i].ProvDone()){
                        sw.WriteLine("TimeSystem отключавет " + ListOfEffects[i].GetName());
                        ListOfEffects.RemoveAt(i);
                    }
                }
                for(int i = 0; i < ListOfNPC.Count; ++i){
                    ListOfNPC[i].MakeTick();
                }
            }
        }
        public Location GetLocation(string nameLocation){
            return DictionaryOfLocations[nameLocation];
        }
        public void TraderChangeLocation(NPC thisNPC, string newlocation){
            DictionaryOfLocations[newlocation].DeleteNPC(thisNPC);
            DictionaryOfLocations[newlocation].AddNPC(thisNPC);
        }
    }
}