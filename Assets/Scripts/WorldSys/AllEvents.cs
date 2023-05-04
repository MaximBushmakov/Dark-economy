using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    public class AllEvents{
        private static AllEvents instance;
        private Dictionary<string, Event> DictionaryOfEvents;
        protected Random rand;
        public static AllEvents getInstance(){
            if (instance == null){
                instance = new AllEvents();
                instance.rand = new Random();
                setEvents();
            }
            return instance;
        }
        private static void setEvents(){
            instance.DictionaryOfEvents = new Dictionary<string, Event>();
            Event newEvent = new Event("Засуха", AllLocationsName, "Погода сильно изменилась, температура резко поднялась, поля терпят неурожай", 3, new List<Effect>{new Effect("Засуха", PriceEffectType, NormalMilletName, 100, 3)}, new List<String>{"Мне вчера колдун рассказал, что маги солнце заклили и оно теперь нас всех сожжёт.", "Знаешь, что-то в последнее время жара усиливается, не к добру это", "Я слышал, что речка тут недалеко совсем засохла, не к добру это."});
            instance.DictionaryOfEvents.Add(newEvent.getName(), newEvent);
            newEvent = new Event("Урожай", AllLocationsName, "Похоже богиня пладородия сжалилась над нами. Скоро в деревнях и городах будет много еды", 3, new List<Effect>{new Effect("Урожай", PriceEffectType, NormalMilletName, 100, 3)}, new List<String>{"Слышал, вчера богине урожая принесли в жертву корову.", "Один знакомый рассказал мне, что в этом году засадили намного больше пшена, чем прежде.", "С каждый днём погода всё лучше и лучше, разве это не прекрасный год?"});
            instance.DictionaryOfEvents.Add(newEvent.getName(), newEvent);
        }
        public Event getRandomEvent(){
            List<string> ArrayAOfEvents = instance.DictionaryOfEvents.Keys.ToList<string>();
            int randid = instance.rand.Next() % ArrayAOfEvents.Count();
            return DictionaryOfEvents[ArrayAOfEvents[randid]];
        }
        private Event getRandomEventExapt(string eventname){
            List<string> ArrayAOfEvents = instance.DictionaryOfEvents.Keys.ToList<string>();
            ArrayAOfEvents.Remove(eventname);
            int randid = instance.rand.Next() % ArrayAOfEvents.Count();
            return DictionaryOfEvents[ArrayAOfEvents[randid]];
        }
        public List<string> getRumors(Event currentEvent, int NPCcount){
            List<string> ListOfRumors = new List<string>();
            int correctRumorNumber = NPCcount * 4 / 10;
            for(int i = 0; i < correctRumorNumber; ++i){
                ListOfRumors.Add(currentEvent.getRumors()[instance.rand.Next() % currentEvent.getRumors().Count]);
            }
            Event randEvent;
            for(int i = 0; i < NPCcount - correctRumorNumber; ++i){
                randEvent = instance.getRandomEventExapt(currentEvent.getName());
                ListOfRumors.Add(randEvent.getRumors()[instance.rand.Next() % randEvent.getRumors().Count]);
            }
            return ListOfRumors;
        }

    }
}

// Напиши притчу о старце