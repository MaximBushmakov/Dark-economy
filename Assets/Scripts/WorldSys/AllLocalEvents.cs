using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    public class AllLocalEvents{
        private static AllLocalEvents instance;
        private Dictionary<int, LocalEvent> DictionaryOfGoodRoadEvents;
        private List<int> GoodRoadEventsStartEvents;
        private Dictionary<int, LocalEvent> DictionaryOfBadRoadEvents;
        private List<int> BadRoadEventsStartEvents;
        private Dictionary<int, LocalEvent> DictionaryOfGoodTownEvents;
        private List<int> GoodTownEventsStartEvents;
        private Dictionary<int, LocalEvent> DictionaryOfBadTownEvents;
        private List<int> BadTownEventsStartEvents;
        private Dictionary<int, LocalEvent> DictionaryOfGoodVillageEvents;
        private List<int> GoodVillageEventsStartEvents;
        private Dictionary<int, LocalEvent> DictionaryOfBadVillageEvents;
        private List<int> BadVillageEventsStartEvents;
        protected Random rand;
        public static AllLocalEvents GetInstance(){
            if (instance == null){
                instance = new AllLocalEvents();
                instance.rand = new Random();
                instance.SetEvents();
            }
            return instance;
        }
        public void SetEvents(){
            // Good Road
            DictionaryOfGoodRoadEvents = new Dictionary<int, LocalEvent>();
            GoodRoadEventsStartEvents = new List<int>();
            DictionaryOfGoodRoadEvents.Add(0, new LocalEvent("Найдена потерянная повозка", GoodRoadEventName, "На окраине дороги вы находите чью-то потерянную повозку, внутри лежат какие-то товары. Есть варианты: забрать товары или забрать из повозки деньги.", new List<int>(){1, 2}, new List<LocalEventEffect>()));
            DictionaryOfGoodRoadEvents.Add(1, new LocalEvent("Найдено золото", GoodRoadEventName, "Разрывая повозку, на дну вы находите мешочек с золотом", new List<int>(), new List<LocalEventEffect>(){new LocalEventEffect(KapitalLocalEffectName, 100)}));
            DictionaryOfGoodRoadEvents.Add(2, new LocalEvent("Найдено зерно", GoodRoadEventName, "Разрывая повозку, вы находите немного зерна", new List<int>(), new List<LocalEventEffect>(){new LocalEventEffect(NormalMilletName, 2)}));
            GoodRoadEventsStartEvents.Add(0);
            // Good Town
            DictionaryOfGoodTownEvents = new Dictionary<int, LocalEvent>();
            // Good Village
            DictionaryOfGoodVillageEvents = new Dictionary<int, LocalEvent>();
            // Bad Road
            DictionaryOfBadRoadEvents = new Dictionary<int, LocalEvent>();
            // Bad Towm
            DictionaryOfBadTownEvents = new Dictionary<int, LocalEvent>();
            // Bad Village
            DictionaryOfBadVillageEvents = new Dictionary<int, LocalEvent>();
        }
        public LocalEvent GetEvent(int id, string type){
            switch (type){
                case GoodRoadEventName:
                	return DictionaryOfGoodRoadEvents[id];
                case BadRoadEventName:
                    return DictionaryOfBadRoadEvents[id];
                case GoodTownEventName:
                    return DictionaryOfGoodTownEvents[id];
                case BadTownEventName:
                    return DictionaryOfBadTownEvents[id];
                case GoodVillageEventName:
                    return DictionaryOfGoodVillageEvents[id];
                case BadVillageEventName:
                    return DictionaryOfBadVillageEvents[id];
                default:
                    return new LocalEvent("", "", "", new List<int>(), new List<LocalEventEffect>());
            }
        }
        public LocalEvent GetRandomEvent(int luck, string typeLocation){
            if(rand.Next() % 100 > (30 + luck * 6 / 10)){
                //Bad
                switch (typeLocation){
                    case RoadName:
                	    return DictionaryOfBadRoadEvents[BadRoadEventsStartEvents[rand.Next() % BadRoadEventsStartEvents.Count]];
                    case VillageName:
                        return DictionaryOfBadVillageEvents[BadVillageEventsStartEvents[rand.Next() % BadVillageEventsStartEvents.Count]];
                    case TownName:
                        return DictionaryOfBadTownEvents[BadTownEventsStartEvents[rand.Next() % BadTownEventsStartEvents.Count]];
                    default:
                        return new LocalEvent("", "", "", new List<int>(), new List<LocalEventEffect>());
                }
            } else{
                switch (typeLocation){
                    case RoadName:
                	    return DictionaryOfGoodRoadEvents[GoodRoadEventsStartEvents[rand.Next() % GoodRoadEventsStartEvents.Count]];
                    case VillageName:
                        return DictionaryOfGoodVillageEvents[GoodVillageEventsStartEvents[rand.Next() % GoodVillageEventsStartEvents.Count]];
                    case TownName:
                        return DictionaryOfGoodTownEvents[GoodTownEventsStartEvents[rand.Next() % GoodTownEventsStartEvents.Count]];
                    default:
                        return new LocalEvent("", "", "", new List<int>(), new List<LocalEventEffect>());
                }
            }
        }
    }
}