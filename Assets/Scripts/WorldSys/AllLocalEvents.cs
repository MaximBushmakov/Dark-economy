using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    public class AllLocalEvents
    {
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
        private Dictionary<int, LocalEvent> DictionaryOfStoryEvents;
        protected Random rand;
        public static AllLocalEvents GetInstance()
        {
            if (instance == null)
            {
                instance = new AllLocalEvents
                {
                    rand = new Random()
                };
                instance.LoadEventsFromJson("Assets/Scripts/WorldSys/local_events.json");
            }
            return instance;
        }

        private void LoadEventsFromJson(string jsonFilePath)
        {
            string json = File.ReadAllText(jsonFilePath);
            var localEventDtos = JsonConvert.DeserializeObject<List<LocalEventDto>>(json);

            DictionaryOfGoodRoadEvents = new Dictionary<int, LocalEvent>();
            DictionaryOfBadRoadEvents = new Dictionary<int, LocalEvent>();
            DictionaryOfGoodTownEvents = new Dictionary<int, LocalEvent>();
            DictionaryOfBadTownEvents = new Dictionary<int, LocalEvent>();
            DictionaryOfGoodVillageEvents = new Dictionary<int, LocalEvent>();
            DictionaryOfBadVillageEvents = new Dictionary<int, LocalEvent>();
            DictionaryOfStoryEvents = new Dictionary<int, LocalEvent>();

            GoodRoadEventsStartEvents = new List<int>();
            BadRoadEventsStartEvents = new List<int>();
            GoodTownEventsStartEvents = new List<int>();
            BadTownEventsStartEvents = new List<int>();
            GoodVillageEventsStartEvents = new List<int>();
            BadVillageEventsStartEvents = new List<int>();

            foreach (var dto in localEventDtos)
            {
                var effects = dto.ListOfEffects.Select(e => new LocalEventEffect(e.Type, e.Baf)).ToList();
                var localEvent = new LocalEvent(dto.Name, dto.Type, dto.Text, dto.ListOfAnswerId, dto.ListOfAnswers, effects);

                switch (dto.Type)
                {
                    case GoodRoadEventName:
                        DictionaryOfGoodRoadEvents.Add(DictionaryOfGoodRoadEvents.Count, localEvent);
                        GoodRoadEventsStartEvents.Add(DictionaryOfGoodRoadEvents.Count - 1);
                        break;
                    case BadRoadEventName:
                        DictionaryOfBadRoadEvents.Add(DictionaryOfBadRoadEvents.Count, localEvent);
                        BadRoadEventsStartEvents.Add(DictionaryOfBadRoadEvents.Count - 1);
                        break;
                    case GoodTownEventName:
                        DictionaryOfGoodTownEvents.Add(DictionaryOfGoodTownEvents.Count, localEvent);
                        GoodTownEventsStartEvents.Add(DictionaryOfGoodTownEvents.Count - 1);
                        break;
                    case BadTownEventName:
                        DictionaryOfBadTownEvents.Add(DictionaryOfBadTownEvents.Count, localEvent);
                        BadTownEventsStartEvents.Add(DictionaryOfBadTownEvents.Count - 1);
                        break;
                    case GoodVillageEventName:
                        DictionaryOfGoodVillageEvents.Add(DictionaryOfGoodVillageEvents.Count, localEvent);
                        GoodVillageEventsStartEvents.Add(DictionaryOfGoodVillageEvents.Count - 1);
                        break;
                    case BadVillageEventName:
                        DictionaryOfBadVillageEvents.Add(DictionaryOfBadVillageEvents.Count, localEvent);
                        BadVillageEventsStartEvents.Add(DictionaryOfBadVillageEvents.Count - 1);
                        break;
                    case StoryEventName:
                        DictionaryOfStoryEvents.Add(DictionaryOfStoryEvents.Count, localEvent);
                        break;
                }
            }
        }
        public LocalEvent GetEvent(int id, string type)
        {
            return type switch
            {
                GoodRoadEventName => DictionaryOfGoodRoadEvents[id],
                BadRoadEventName => DictionaryOfBadRoadEvents[id],
                GoodTownEventName => DictionaryOfGoodTownEvents[id],
                BadTownEventName => DictionaryOfBadTownEvents[id],
                GoodVillageEventName => DictionaryOfGoodVillageEvents[id],
                BadVillageEventName => DictionaryOfBadVillageEvents[id],
                StoryEventName => DictionaryOfStoryEvents[id],
                _ => new LocalEvent("", "", "", new List<int>(), new List<string>(), new List<LocalEventEffect>()),
            };
        }
        public LocalEvent GetRandomEvent(int luck, string typeLocation)
        {
            if (rand.Next() % 100 > (30 + luck * 6 / 10))
            {
                //Bad
                return typeLocation switch
                {
                    RoadName => DictionaryOfBadRoadEvents[BadRoadEventsStartEvents[rand.Next() % BadRoadEventsStartEvents.Count]],
                    VillageName => DictionaryOfBadVillageEvents[BadVillageEventsStartEvents[rand.Next() % BadVillageEventsStartEvents.Count]],
                    TownName => DictionaryOfBadTownEvents[BadTownEventsStartEvents[rand.Next() % BadTownEventsStartEvents.Count]],
                    _ => new LocalEvent("", "", "", new List<int>(), new List<string>(), new List<LocalEventEffect>()),
                };
            }
            else
            {
                return typeLocation switch
                {
                    RoadName => DictionaryOfGoodRoadEvents[GoodRoadEventsStartEvents[rand.Next() % GoodRoadEventsStartEvents.Count]],
                    VillageName => DictionaryOfGoodVillageEvents[GoodVillageEventsStartEvents[rand.Next() % GoodVillageEventsStartEvents.Count]],
                    TownName => DictionaryOfGoodTownEvents[GoodTownEventsStartEvents[rand.Next() % GoodTownEventsStartEvents.Count]],
                    _ => new LocalEvent("", "", "", new List<int>(), new List<string>(), new List<LocalEventEffect>()),
                };
            }
        }
    }

    public class LocalEventEffectDto
    {
        public string Type { get; set; }
        public int Baf { get; set; }
    }

    public class LocalEventDto
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public List<int> ListOfAnswerId { get; set; }
        public List<string> ListOfAnswers { get; set; }
        public List<LocalEventEffectDto> ListOfEffects { get; set; }
    }
}
