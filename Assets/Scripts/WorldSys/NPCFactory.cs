using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace WorldSystem
{
    public class NPCFactory
    {
        private readonly NPCActivityStrategyFactory strategyFactory;

        public NPCFactory()
        {
            strategyFactory = new NPCActivityStrategyFactory();
        }

        public ReadOnlyDictionary<string, NPC> CreateNPCsFromJson(string jsonFilePath)
        {
            var npcDict = new Dictionary<string, NPC>();
            var jsonString = File.ReadAllText(jsonFilePath);
            var json = JObject.Parse(jsonString);
            foreach (var npcJson in json["npcs"])
            {
                string name = npcJson["name"].ToString();
                string location = npcJson["location"].ToString();
                string type = npcJson["type"].ToString();
                List<string> produceMaterials = npcJson["produceMaterials"].ToObject<List<string>>();
                List<string> produceProducts = npcJson["produceProducts"].ToObject<List<string>>();
                List<string> subLocations = npcJson["subLocations"].ToObject<List<string>>();
                int wisdomLevel = npcJson["wisdomLevel"].ToObject<int>();
                int kapital = npcJson["kapital"].ToObject<int>();
                int reputation = npcJson["reputation"].ToObject<int>();
                var npc = new NPC(name, location, type, produceMaterials, produceProducts, subLocations, wisdomLevel, kapital, reputation);
                var strategyJson = (JObject)npcJson["activityStrategy"];;
                var strategy = strategyFactory.CreateStrategyFromJson(strategyJson);
                npc.SetStrategy(strategy);
                npcDict[name] = npc;
            }
        return new ReadOnlyDictionary<string, NPC>(npcDict);
        }
    }
}