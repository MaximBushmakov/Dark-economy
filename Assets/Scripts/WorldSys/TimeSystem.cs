using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using static WorldSystem.GlobalNames;
#pragma warning disable CS0642

namespace WorldSystem
{
    public class TimeSystem
    {
        private static TimeSystem instance;
        private List<LocalEvent> _events = new();
        private Event _globEvent;
        private List<Product> ListOfProducts = new();
        private List<NPC> ListOfNPC = new();
        private List<Effect> ListOfEffects = new();
        private Dictionary<string, Location> DictionaryOfLocations = new();
        private StreamWriter sw;
        private Event currentEvent;
        protected Random rand;
        public ProductFactory productFactory;

        public TimeSystem()
        {
            ListOfNPC = new List<NPC>();
            ListOfProducts = new List<Product>();
            DictionaryOfLocations = new Dictionary<string, Location>();
            ListOfEffects = new List<Effect>();
            productFactory = new ProductFactory();
            sw = new StreamWriter("Logs.txt");
            rand = new Random();
        }

        public TimeSystem(bool isNew)
        {
            if (isNew)
            {
                ListOfNPC = new List<NPC>();
                ListOfProducts = new List<Product>();
                DictionaryOfLocations = new Dictionary<string, Location>();
                ListOfEffects = new List<Effect>();
                sw = new StreamWriter("Logs.txt");
                productFactory = new ProductFactory();
                rand = new Random();
            }
        }

        public static TimeSystem GetInstance()
        {
            instance ??= new TimeSystem();
            return instance;
        }

        public static void Reset()
        {
            instance.EndLog();
            foreach ((_, Location loc) in instance.DictionaryOfLocations)
            {
                loc.Reset();
            }
            instance.DictionaryOfLocations = null;
            instance.ListOfEffects = null;
            instance.ListOfNPC = null;
            instance.ListOfProducts = null;
            instance = new TimeSystem();
        }

        public void Initialize(List<Location> locationList, Event curEvent)
        {
            DictionaryOfLocations = locationList
                .ToDictionary(loc => loc.GetName(), loc => loc);
            currentEvent = curEvent;
            ListOfNPC = locationList.SelectMany(loc => loc.GetNPC()).ToList();
            ListOfEffects = locationList.SelectMany(loc => loc.GetEffects()).ToList();
            ListOfEffects.AddRange(ListOfNPC.SelectMany(npc => npc.GetEffects()));
            ListOfProducts = ListOfNPC.SelectMany(npc => npc.GetInventoryProducts()).ToList();
        }

        public void AddEvent(LocalEvent e)
        {
            _events.Add(e);
        }
        public List<LocalEvent> ReadEvents()
        {
            List<LocalEvent> ans = new List<LocalEvent>((IEnumerable<LocalEvent>)_events);
            _events.Clear();
            return ans;

        }
        public Event GetActiveEvent()
        {
            Event e = _globEvent;
            _globEvent = null;
            return e;
        }
        public Event GetCurrentEvent()
        {
            return currentEvent;
        }

        public void AddEffecttoTimeSystem(Effect newEffect)
        {
            ListOfEffects.Add(newEffect);
            sw.WriteLine(newEffect.GetName() + " теперь часть системы времени");
        }
        public void AddNPCtoTimeSystem(NPC newNPC)
        {
            ListOfNPC.Add(newNPC);
            DictionaryOfLocations[newNPC.GetLocation()].AddNPC(newNPC);
            sw.WriteLine(newNPC.GetProfessionType() + " " + newNPC.GetName() + " теперь часть системы времени");
        }
        public void AddProducttoTimeSystem(Product newProduct)
        {
            ListOfProducts.Add(newProduct);
            sw.WriteLine(newProduct.GetSubType() + " теперь часть системы времени");
        }
        public void AddLocationtoTimeSystem(Location location)
        {
            DictionaryOfLocations.Add(location.GetName(), location);
        }
        public void WriteLog(string text)
        {
            sw.WriteLine(text);
        }
        public void EndLog()
        {
            sw?.Close();
        }
        public void StartRumors(Event thisevent)
        {
            List<string> ListofRumors = AllEvents.GetInstance().GetRumors(thisevent, ListOfNPC.Count);
            int randid;
            for (int i = 0; i < ListOfNPC.Count; ++i)
            {
                randid = rand.Next() % ListofRumors.Count;
                ListOfNPC[i].SetRumor(ListofRumors[randid]);
                WriteLog(ListOfNPC[i].GetProfessionType() + " " + ListOfNPC[i].GetName() + " получает слух: " + ListOfNPC[i].GetRumor());
                ListofRumors.RemoveAt(randid);
            }

        }
        public void StartFirstEvent()
        {
            currentEvent = AllEvents.GetInstance().GetRandomEvent();
            StartRumors(currentEvent);
        }
        public void MakeEventStep()
        {
            if (instance.currentEvent.Start())
            {
                _globEvent = instance.currentEvent;
                List<Effect> newEffects = currentEvent.GetEffects();
                string location = currentEvent.GetLocation();
                for (int i = 0; i < newEffects.Count; ++i)
                {
                    GetInstance().AddEffecttoTimeSystem(newEffects[i]);
                }
                if (location == AllLocationsName)
                {
                    foreach (var thislocation in DictionaryOfLocations)
                    {
                        for (int i = 0; i < newEffects.Count; ++i)
                        {
                            thislocation.Value.AddEffect(newEffects[i]);
                        }
                    }
                }
                else
                {
                    foreach (var thislocation in DictionaryOfLocations)
                    {
                        for (int i = 0; i < newEffects.Count; ++i)
                        {
                            if (location == thislocation.Key)
                            {
                                thislocation.Value.AddEffect(newEffects[i]);
                            }
                        }
                    }
                }
                currentEvent = AllEvents.GetInstance().GetRandomEvent();
                StartRumors(currentEvent);
            }
        }
        public void MakeTicks(int n)
        {
            for (int j = 0; j < n; ++j)
            {
                MakeEventStep();
                foreach (var location in DictionaryOfLocations)
                {
                    location.Value.MakeTick();
                }
                for (int i = ListOfProducts.Count - 1; i >= 0; --i)
                {
                    ListOfProducts[i].MakeTick();
                    if (ListOfProducts[i].GetQuality() == 0)
                    {
                        sw.WriteLine("TimeSystem отключавет " + ListOfProducts[i].GetSubType());
                        ListOfProducts.RemoveAt(i);
                    }
                }
                for (int i = ListOfEffects.Count - 1; i >= 0; --i)
                {
                    ListOfEffects[i].MakeTick();
                    if (ListOfEffects[i].ProvDone())
                    {
                        sw.WriteLine("TimeSystem отключавет " + ListOfEffects[i].GetName());
                        ListOfEffects.RemoveAt(i);
                    }
                }
                for (int i = 0; i < ListOfNPC.Count; ++i)
                {
                    ListOfNPC[i].MakeTick();
                }
            }
        }
        public Location GetLocation(string nameLocation)
        {
            return DictionaryOfLocations[nameLocation];
        }
        public List<Location> GetLocationList()
        {
            return DictionaryOfLocations.Values.ToList();
        }
        public void TraderChangeLocation(NPC thisNPC, string newlocation)
        {
            DictionaryOfLocations[newlocation].DeleteNPC(thisNPC);
            DictionaryOfLocations[newlocation].AddNPC(thisNPC);
        }
    }
}