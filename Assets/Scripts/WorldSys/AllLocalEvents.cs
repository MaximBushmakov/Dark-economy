using System;
using System.Collections.Generic;
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
                instance.SetEvents();
            }
            return instance;
        }
        public void SetEvents()
        {
            // Good Road
            DictionaryOfGoodRoadEvents = new Dictionary<int, LocalEvent>();
            GoodRoadEventsStartEvents = new List<int>();
            DictionaryOfGoodRoadEvents.Add(0, new LocalEvent("Найдена потерянная повозка", GoodRoadEventName, "На окраине дороги вы находите чью-то потерянную повозку, внутри лежат какие-то товары. Есть варианты: забрать товары или забрать из повозки деньги.", new List<int>() { 1, 2 }, new List<string>() {"Деньги", "Товары"}, new List<LocalEventEffect>()));
            DictionaryOfGoodRoadEvents.Add(1, new LocalEvent("Найдено золото", GoodRoadEventName, "Разрывая повозку, на дну вы находите мешочек с золотом", new List<int>(), new List<string>(), new List<LocalEventEffect>() { new LocalEventEffect(KapitalLocalEffectName, 100) }));
            DictionaryOfGoodRoadEvents.Add(2, new LocalEvent("Найдено зерно", GoodRoadEventName, "Разрывая повозку, вы находите немного зерна", new List<int>(), new List<string>(), new List<LocalEventEffect>() { new LocalEventEffect(NormalMilletName, 2) }));
            GoodRoadEventsStartEvents.Add(0);
            // Good Town
            DictionaryOfGoodTownEvents = new Dictionary<int, LocalEvent>();
            GoodTownEventsStartEvents = new List<int>();
            DictionaryOfGoodTownEvents.Add(0, new LocalEvent("Другой Торговец просит спрятать его товар", GoodTownEventName, "В городе вас в переулке находит другой торговец, он просит вас спрятать его товар, а потом вернуть его. Вы можете спрятать товар и получить за это репутацию или забрать товар себе", new List<int>() { 1, 2 }, new List<string>() { "Спрятать", "Забрать" }, new List<LocalEventEffect>()));
            DictionaryOfGoodTownEvents.Add(1, new LocalEvent("Товар спрятан", GoodTownEventName, "Вам удалось спрятать товар так, чтобы его никто не нашёл. Через несколько дней забрав оттуда свой товар, торговец разнёс о вашей честности слух во всех городах", new List<int>(), new List<string>(), new List<LocalEventEffect>() { new LocalEventEffect(ReputationLocalEffectName, 5) }));
            DictionaryOfGoodTownEvents.Add(2, new LocalEvent("Товар украден", GoodTownEventName, "Вы украли товар у другого торговца. Разумеется, теперь вы сможете забрать его себе, но слухи о вашем бесчестье уже пущены в народ", new List<int>(), new List<string>(), new List<LocalEventEffect>() { new LocalEventEffect(GoldenFlourName, 5), new LocalEventEffect(ReputationLocalEffectName, -10) }));
            GoodTownEventsStartEvents.Add(0);
            // Good Village
            DictionaryOfGoodVillageEvents = new Dictionary<int, LocalEvent>();
            GoodVillageEventsStartEvents = new List<int>();
            DictionaryOfGoodVillageEvents.Add(0, new LocalEvent("Большой урожай", GoodVillageEventName, "У местоного фермера случился большой урожай. Он решил поделиться им с вами.", new List<int>() { }, new List<string>(), new List<LocalEventEffect>() { new LocalEventEffect(NormalFlourName, 2) }));
            GoodVillageEventsStartEvents.Add(0);
            // Bad Road
            DictionaryOfBadRoadEvents = new Dictionary<int, LocalEvent>();
            BadRoadEventsStartEvents = new List<int>();
            DictionaryOfBadRoadEvents.Add(0, new LocalEvent("Часть товара в пути испортился", BadRoadEventName, "Часть товара по дороге испортилось, возможно следует выбросить часть товара, чтобы сохранить другую", new List<int>() { 1, 2 }, new List<string>() { "Выбросить", "Оставить" }, new List<LocalEventEffect>()));
            DictionaryOfBadRoadEvents.Add(1, new LocalEvent("Выброшена небольшая часть товара", BadRoadEventName, "Вы выбросили часть товара и остальная часть была сохранена", new List<int>(), new List<string>(), new List<LocalEventEffect>() { new LocalEventEffect(MinusProductLocalEffectName, 1) }));
            DictionaryOfBadRoadEvents.Add(2, new LocalEvent("Выброшена большая часть товара", BadRoadEventName, "Из-за того что вы не выбросили часть товара, большое количество друцгих товаров пришла в негодность", new List<int>(), new List<string>(), new List<LocalEventEffect>() { new LocalEventEffect(MinusProductLocalEffectName, 2) }));
            BadRoadEventsStartEvents.Add(0);
            // Bad Town
            DictionaryOfBadTownEvents = new Dictionary<int, LocalEvent>();
            BadTownEventsStartEvents = new List<int>();
            DictionaryOfBadTownEvents.Add(0, new LocalEvent("Ограбление!", BadTownEventName, "Что же плохого может случиться в тёмном переулке? Конечно же ограбление! Вы можете попытаться бежать или же спокойно отдать часть ваших денег", new List<int>() { 1, 2 }, new List<string>() { "Бежать", "Отдать" }, new List<LocalEventEffect>()));
            DictionaryOfBadTownEvents.Add(1, new LocalEvent("Побег", BadTownEventName, "Вы решили сбежать, однако для этого пришлось оставить часть товара.", new List<int>(), new List<string>(), new List<LocalEventEffect>() { new LocalEventEffect(MinusProductLocalEffectName, 1) }));
            DictionaryOfBadTownEvents.Add(2, new LocalEvent("Откуп", BadTownEventName, "Вы смогли откупиться от грабителей. Спрятав часть своих денег, вы отдаёте оставшееся преступникам", new List<int>(), new List<string>(), new List<LocalEventEffect>() { new LocalEventEffect(KapitalLocalEffectName, -400) }));
            BadTownEventsStartEvents.Add(0);
            // Bad Village
            DictionaryOfBadVillageEvents = new Dictionary<int, LocalEvent>();
            BadVillageEventsStartEvents = new List<int>();
            DictionaryOfBadVillageEvents.Add(0, new LocalEvent("Кража в доме", BadVillageEventName, "Пока вы мирно спали в доме, кто-то украл у вас деньги", new List<int>() { }, new List<string>(), new List<LocalEventEffect>() { new LocalEventEffect(KapitalLocalEffectName, -100) }));
            BadVillageEventsStartEvents.Add(0);
            DictionaryOfStoryEvents = new Dictionary<int, LocalEvent>();
            DictionaryOfStoryEvents.Add(0, new LocalEvent("Начало истории", StoryEventName, "Йохан, чудесное имя. Ваше имя. Я всем сердцем желаю, чтобы вы наслаждались даным вам телом в этом мире. Вы хотите знать, кто вы и где находитесь?", new List<int>() { 2, 1 }, new List<string>() { "Хочу", "Мне не интересно" }, new List<LocalEventEffect>()));
            DictionaryOfStoryEvents.Add(1, new LocalEvent("Приятной игры", StoryEventName, "Тогда, настало время начать ваше приключение. Да сопутсвует вам удача.", new List<int>() { 2, 1 }, new List<string>() { "Хочу", "Мне не интересно" }, new List<LocalEventEffect>()));
            DictionaryOfStoryEvents.Add(2, new LocalEvent("История мира", StoryEventName, "Этот мир можно назвать площадкой игры для богов, полем для проверки навыков их послушников. Но какое дело до этого вам, простому человеку? Для вас, это просто радной мир, мир злата и магии, мир эльфов, людей, гномов и монстров.", new List<int>() { 1, 3 }, new List<string>() { "Назад", "Далее" }, new List<LocalEventEffect>()));
            DictionaryOfStoryEvents.Add(3, new LocalEvent("Кто я?", StoryEventName, "Ваше тело, вы, Йохан, один из людей этого мира, проживающих в деревне на севере, практически у самой границы с землями монстров. После смерти отца, когда ваш старший брат Марк получил землянной надел от отца, вы решили стать торговцем", new List<int>() { 2, 4 }, new List<string>() { "Назад", "Далее" }, new List<LocalEventEffect>()));
            DictionaryOfStoryEvents.Add(4, new LocalEvent("Путь", StoryEventName, "Всё что у вас есть, небольшой запас капитала, немного товаров, что можно продать мельнику и верный друг - осёл по имени Суслик. Станете ли вы владельцем новой великой гильдии, или же умрёте с голову, потратив все деньги? А может сдадитесь и станете работать на брата? Решат лишь ваши действи и щепотка удачи.", new List<int>() { 3, 0, 1 }, new List<string>() { "Назад", "Расскажи с начала", "Я всё понял" }, new List<LocalEventEffect>()));
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
}