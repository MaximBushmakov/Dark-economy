using System;
using System.Collections.Generic;
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
                SetEvents();
            }
            return instance;
        }
        private static void SetEvents()
        {
            instance.DictionaryOfEvents = new Dictionary<string, Event>();
            Event newEvent = new("Засуха", AllLocationsName, "Погода сильно изменилась, температура резко поднялась, поля терпят неурожай", 3, new List<Effect> { new Effect("Засуха", PriceEffectType, NormalMilletName, 20, 3) }, new List<String> { "Мне вчера колдун рассказал, что маги солнце заклили и оно теперь нас всех сожжёт.", "Знаешь, что-то в последнее время жара усиливается, не к добру это", "Я слышал, что речка тут недалеко совсем засохла, не к добру это." });
            instance.DictionaryOfEvents.Add(newEvent.GetName(), newEvent);
            newEvent = new("Урожай", AllLocationsName, "Похоже богиня плодородия сжалилась над нами. Скоро в деревнях и городах будет много еды", 3, new List<Effect> { new Effect("Урожай", PriceEffectType, NormalMilletName, -20, 3) }, new List<String> { "Слышал, вчера богине урожая принесли в жертву корову.", "Один знакомый рассказал мне, что в этом году засадили намного больше пшена, чем прежде.", "С каждый днём погода всё лучше и лучше, разве это не прекрасный год?" });
            instance.DictionaryOfEvents.Add(newEvent.GetName(), newEvent);
        }
        public Event GetRandomEvent()
        {
            List<string> ArrayAOfEvents = instance.DictionaryOfEvents.Keys.ToList();
            int randid = instance.rand.Next() % ArrayAOfEvents.Count();
            return DictionaryOfEvents[ArrayAOfEvents[randid]];
        }
        private Event GetRandomEventExapt(string eventname)
        {
            List<string> ArrayAOfEvents = instance.DictionaryOfEvents.Keys.ToList();
            ArrayAOfEvents.Remove(eventname);
            int randid = instance.rand.Next() % ArrayAOfEvents.Count();
            return DictionaryOfEvents[ArrayAOfEvents[randid]];
        }
        public List<string> GetRumors(Event currentEvent, int NPCcount)
        {
            List<string> ListOfRumors = new();
            int correctRumorNumber = NPCcount * 4 / 10;
            for (int i = 0; i < correctRumorNumber; ++i)
            {
                ListOfRumors.Add(currentEvent.GetRumors()[instance.rand.Next() % currentEvent.GetRumors().Count]);
            }
            Event randEvent;
            for (int i = 0; i < NPCcount - correctRumorNumber; ++i)
            {
                randEvent = instance.GetRandomEventExapt(currentEvent.GetName());
                ListOfRumors.Add(randEvent.GetRumors()[instance.rand.Next() % randEvent.GetRumors().Count]);
            }
            return ListOfRumors;
        }

    }
}
