using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    public class AllLocalEvents{
        private static AllLocalEvents instance;
        private Dictionary<int, LocalEvent> DictionaryOfGoodRoadEvents;
        private Dictionary<int, LocalEvent> DictionaryOfBadRoadEvents;
        private Dictionary<int, LocalEvent> DictionaryOfGoodTownEvents;
        private Dictionary<int, LocalEvent> DictionaryOfBadTownEvents;
        private Dictionary<int, LocalEvent> DictionaryOfGoodVillageEvents;
        private Dictionary<int, LocalEvent> DictionaryOfBadVillageEvents;
        protected Random rand;
        public static AllLocalEvents getInstance(){
            if (instance == null){
                instance = new AllLocalEvents();
                instance.rand = new Random();
                setEvents();
            }
            return instance;
        }
        private static void setEvents(){
            instance.DictionaryOfGoodRoadEvents = new Dictionary<int, LocalEvent>();
            instance.DictionaryOfGoodTownEvents = new Dictionary<int, LocalEvent>();
            instance.DictionaryOfGoodVillageEvents = new Dictionary<int, LocalEvent>();
            instance.DictionaryOfBadRoadEvents = new Dictionary<int, LocalEvent>();
            instance.DictionaryOfBadTownEvents = new Dictionary<int, LocalEvent>();
            instance.DictionaryOfBadVillageEvents = new Dictionary<int, LocalEvent>();
        }
        public LocalEvent getEvent(int id, string type){
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
                    return DictionaryOfGoodRoadEvents[id];
            }
        }
    }
}