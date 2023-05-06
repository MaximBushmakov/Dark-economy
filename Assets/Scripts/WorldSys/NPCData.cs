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
                    new List<string> { "Хата Марка", "Улица", "Поле", "Хата Марка" }),

                new Millworker("Рудольф", "Деревня",
                    new List<string> { "Хата Рудольфа", "Улица", "Мельница", "Хата Рудольфа" }),

                new Fermer("Олег", "Деревня",
                    new List<string> { "Хата Олега", "Улица", "Поле", "Хата Олега" }),

                new Baker("Андрей", "Город",
                    new List<string> { "Дом Андрея", "Улица", "Пекарня", "Дом Андрея" }),

                new Elder("Александро", "Деревня",
                    new List<string> { "Дом Александро", "Улица", "Зал старейшины", "Дом Александро" }),

                new Trader("Джон", new List<string> { "Деревня", "Город" }, new List<List<string>> {
                    new List<string> { ElderProfessionName, FermerProfessionName, MillworkerProfessionName },
                    new List<string> { BakerProfessionName }
                    }, 10)

            }.ToDictionary(npc => npc.GetName(), npc => npc));
        }
    }
}