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
            NPCFactory nPCFactory = new NPCFactory();
            _NPC = nPCFactory.CreateNPCsFromJson("Assets/Scripts/WorldSys/npc.json");
        }
    }
}