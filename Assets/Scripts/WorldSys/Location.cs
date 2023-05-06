using System;
using System.Collections.Generic;
using System.Linq;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    [Serializable]
    public class Location
    {
        public readonly string Name;
        public readonly List<string> Sublocations;
        public readonly string type;
        private List<NPC> listOfNPC;
        private List<NPC> listOfNPCSellers;
        protected List<Effect> ListOfEffects;
        protected Dictionary<string, List<Effect>> DictionaryofPriceEffects;
        [field: NonSerialized]
        protected Random rand;

        public Location(string name, string thisType, List<string> sublocations)
        {
            Name = name;
            type = thisType;
            Sublocations = sublocations;
            listOfNPC = new List<NPC>();
            listOfNPCSellers = new List<NPC>();
            ListOfEffects = new List<Effect>();
            DictionaryofPriceEffects = new Dictionary<string, List<Effect>>();
            rand = new Random();
            TimeSystem.GetInstance().AddLocationtoTimeSystem(this);
        }

        public void AddNPC(NPC newNPC)
        {
            if (sellerNames.Contains(newNPC.GetProfessionType()))
            {
                listOfNPCSellers.Add(newNPC);
            }
            listOfNPC.Add(newNPC);
        }
        public void DeleteNPC(NPC thisNPC)
        {
            listOfNPC.Remove(thisNPC);
        }
        public List<NPC> GetNPC()
        {
            return listOfNPC;
        }
        public NPC FindRandomNPCType(string npcType)
        {
            List<int> correctNPC = new();
            for (int i = 0; i < listOfNPC.Count; ++i)
            {
                if (listOfNPC[i].GetProfessionType() == npcType)
                {
                    correctNPC.Add(i);
                }
            }
            int randNPCId = rand.Next() % correctNPC.Count;
            return listOfNPC[correctNPC[randNPCId]];
        }
        public void ProveEffects()
        {
            for (int i = ListOfEffects.Count - 1; i >= 0; --i)
            {
                if (ListOfEffects[i].ProvDone())
                {
                    TimeSystem.GetInstance().WriteLog(ListOfEffects[i].GetName() + " перестаёт оказывать эффект на " + Name);
                    if (ListOfEffects[i].GetEffectType() == PriceEffectType)
                    {
                        DictionaryofPriceEffects[ListOfEffects[i].GetOwner()].Remove(ListOfEffects[i]);
                    }
                    ListOfEffects.RemoveAt(i);
                }
            }
        }
        public void AddEffect(Effect thisEffect)
        {
            ListOfEffects.Add(thisEffect);
            if (thisEffect.GetEffectType() == PriceEffectType)
            {
                if (!DictionaryofPriceEffects.ContainsKey(thisEffect.GetOwner()))
                {
                    DictionaryofPriceEffects.Add(thisEffect.GetOwner(), new List<Effect>());
                }
                DictionaryofPriceEffects[thisEffect.GetOwner()].Add(thisEffect);
            }
        }
        public Dictionary<string, List<Effect>> GetDictionaryPrice()
        {
            return DictionaryofPriceEffects;
        }
        public void MakeTick()
        {
            ProveEffects();
        }
        public bool NPCBuyFood(NPC thisNPC)
        {
            for (int i = 0; i < listOfNPCSellers.Count; ++i)
            {
                if (listOfNPCSellers[i].BuyFood(thisNPC))
                {
                    return true;
                }
            }
            return false;
        }
        public List<NPC> FindNPCInSublocation(string sublocationName)
        {
            List<NPC> ListOfNPCSub = new();
            for (int i = 0; i < listOfNPC.Count; ++i)
            {
                if (listOfNPC[i].GetSublocation() == sublocationName)
                {
                    ListOfNPCSub.Add(listOfNPC[i]);
                }
            }
            return ListOfNPCSub;
        }
    }
}