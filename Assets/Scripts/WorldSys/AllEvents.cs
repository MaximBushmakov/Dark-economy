using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    public class AllEvents
    {
        private static AllEvents instance;
        private Dictionary<string, Event> DictionaryOfEvents;
        private Random rand;
        public static AllEvents GetInstance()
        {
            if (instance == null)
            {
                instance = new AllEvents
                {
                    rand = new Random()
                };
                instance.LoadEventsFromJson("Assets/Scripts/WorldSys/events.json");
            }
            return instance;
        }

        private void LoadEventsFromJson(string jsonFilePath)
        {
            string json = File.ReadAllText(jsonFilePath);
            var eventDtos = JsonConvert.DeserializeObject<List<EventDto>>(json);

            DictionaryOfEvents = eventDtos.ToDictionary(
                dto => dto.Name,
                dto => new Event(dto.Name, dto.Location, dto.Text, dto.TimeToStart, dto.Effects.Select(e => new Effect(e.Name, e.Type, e.Owner, e.EffectBaf, e.LifeTime)).ToList(), dto.Rumors)
            );
        }
        public Event GetRandomEvent()
        {
            List<string> ArrayAOfEvents = DictionaryOfEvents.Keys.ToList();
            int randid = rand.Next() % ArrayAOfEvents.Count;
            return DictionaryOfEvents[ArrayAOfEvents[randid]];
        }
        private Event GetRandomEventExapt(string eventname)
        {
            List<string> ArrayAOfEvents = DictionaryOfEvents.Keys.ToList();
            ArrayAOfEvents.Remove(eventname);
            int randid = rand.Next() % ArrayAOfEvents.Count;
            return DictionaryOfEvents[ArrayAOfEvents[randid]];
        }
        public List<string> GetRumors(Event currentEvent, int NPCcount)
        {
            List<string> ListOfRumors = new();
            int correctRumorNumber = NPCcount * 4 / 10;
            for (int i = 0; i < correctRumorNumber; ++i)
            {
                ListOfRumors.Add(currentEvent.GetRumors()[rand.Next() % currentEvent.GetRumors().Count]);
            }
            Event randEvent;
            for (int i = 0; i < NPCcount - correctRumorNumber; ++i)
            {
                randEvent = GetRandomEventExapt(currentEvent.GetName());
                ListOfRumors.Add(randEvent.GetRumors()[rand.Next() % randEvent.GetRumors().Count]);
            }
            return ListOfRumors;
        }
    }
    public class EventDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Text { get; set; }
        public int TimeToStart { get; set; }
        public List<EffectDto> Effects { get; set; }
        public List<string> Rumors { get; set; }
    }
    public class EffectDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public int EffectBaf { get; set; }
        public int LifeTime { get; set; }
    }
}