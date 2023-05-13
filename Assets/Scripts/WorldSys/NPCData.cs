using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static WorldSystem.GlobalNames;
namespace WorldSystem
{
    public static class NPCData
    {
        private static ReadOnlyDictionary<string, NPC> _NPC;
        public static ReadOnlyDictionary<string, NPC> NPC { get => _NPC; }

        public static void Initialize(List<NPC> NPCList)
        {
            _NPC = new ReadOnlyDictionary<string, NPC>(NPCList
                .ToDictionary(npc => npc.GetName(), npc => npc));
        }

        public static void Initialize()
        {
            _NPC = new ReadOnlyDictionary<string, NPC>(new List<NPC>
            {
                new Fermer("Марк", "Деревня",
                    new List<string> { "Дом Марка", "Деревня", "Поле", "Дом Марка" }),

                new Millworker("Рудольф", "Деревня",
                    new List<string> { "Мельница", "Деревня", "Мельница", "Дом Рудольфа" }),

                new Fermer("Олег", "Деревня",
                    new List<string> { "Дом Олега", "Деревня", "Поле", "Дом Олега" }),

                new Baker("Андрей", "Город",
                    new List<string> { "Дом Андрея", "Город", "Пекарня", "Дом Андрея" }),

                new Elder("Александро", "Деревня",
                    new List<string> { "Дом Александро", "Зал старейшины", "Зал старейшины", "Дом Александро" }),

                new Trader("Джон", new List<string> { "Деревня", "Город" }, new List<List<string>> {
                    new List<string> { ElderProfessionName, FermerProfessionName, MillworkerProfessionName },
                    new List<string> { BakerProfessionName }
                    }, 50),
                new Woodman("Кирилл", "Деревня",
                    new List<string> { "Дом Кирилла", "Деревня", "Лес", "Дом Кирилла" }),
                new Woodman("Крис", "Деревня",
                    new List<string> { "Дом Криса", "Лес", "Деревня", "Дом Криса" }),
                new Woodworker("Артур", "Город",
                    new List<string> { "Дом Артура", "Город", "Плотницкая", "Дом Артура" }),
                new Seaman("Кристофер", "Город",
                    new List<string> { "Порт", "Порт", "Порт", "Порт", SeaName, SeaName, SeaName, SeaName}),
                new Seaman("Кракен", "Город",
                    new List<string> { SeaName, SeaName, SeaName, SeaName, "Порт", "Порт", "Порт", "Порт"}),
                new Trader("Джонатан", new List<string> { "Деревня", "Город" }, new List<List<string>> {
                    new List<string> { WoodmanProfessionName},
                    new List<string> { WoodworkerProfessionName, SeamanProfessionName }
                    }, 50),
                new Miner("Герман", "Деревня",
                    new List<string> { "Дом Германа", "Шахта", "Деревня", "Дом Германа" }),
                new Miner("Густав", "Деревня",
                    new List<string> { "Дом Густава", "Деревня", "Шахта", "Дом Густава" }),
                new Blacksmith("Даниил", "Город",
                    new List<string> { "Дом Даниила", "Город", "Кузница", "Дом Даниила" }),
                new Potter("Гарри", "Город",
                    new List<string> { "Дом Гарри", "Город", "Гончарная", "Дом Гарри" }),
                new Trader("Каспар", new List<string> { "Деревня", "Город" }, new List<List<string>> {
                    new List<string> { MinerProfessionName},
                    new List<string> { BlacksmithProfessionName, PotterProfessionName, SeamanProfessionName }
                    }, 50),
                new Hunter("Платон", "Деревня",
                    new List<string> { "Дом Платона", "Лес", "Деревня", "Дом Платона" }),
                new Hunter("Прокл", "Деревня",
                    new List<string> { "Дом Прокла", "Деревня", "Лес", "Дом Прокла" }),
                new Cook("Руслан", "Город",
                    new List<string> { "Дом Руслана", "Город", "Общественная кухня", "Дом Руслана" }),
                new Shoemaker("Фадей", "Город",
                    new List<string> { "Дом Фадея", "Город", "Мастерская Сапожника", "Дом Фадея" }),
                new TavernKeeper("Эдмунд", "Город",
                    new List<string> { "Дом Эдмунда", "Таверна", "Таверна", "Дом Эдмунда" }),
                new Trader("Терентий", new List<string> { "Деревня", "Город" }, new List<List<string>> {
                    new List<string> { HunterProfessionName},
                    new List<string> { CookProfessionName, TavernKeeperProfessionName, ShoemakerProfessionName, SeamanProfessionName }
                    }, 50),
                new Brewer("Соломон", "Город",
                    new List<string> { "Дом Соломона", "Пивоварня", "Город", "Дом Соломона" }),
                 new Trader("Иван", new List<string> { "Деревня", "Город" }, new List<List<string>> {
                    new List<string> { FermerProfessionName},
                    new List<string> { BrewerProfessionName, TavernKeeperProfessionName}
                    }, 50),
                new Bortnik("Бордей", "Деревня",
                    new List<string> { "Дом Бордея", "Деревня", "Лес", "Дом Бордея" }),
                new Priest("Эрик", "Город",
                    new List<string> { "Дом Эрика", "Храм", "Храм", "Дом Эрика" }),
                new Trader("Феликс", new List<string> { "Деревня", "Город" }, new List<List<string>> {
                    new List<string> { BortnikProfessionName},
                    new List<string> { PriestProfessionName, SeamanProfessionName }
                    }, 50)
            }.ToDictionary(npc => npc.GetName(), npc => npc));
        }
    }
}