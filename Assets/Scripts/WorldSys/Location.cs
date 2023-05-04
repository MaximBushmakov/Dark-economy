using System;
using System.Collections.Generic;
using static WorldSystem.GlobalNames;
using System.Linq;

namespace WorldSystem
{
    public class Location{
        protected string name;
        protected string type;
        private List<NPC> listOfNPC;
        private List<NPC> listOfNPCSellers;
        protected List<Effect> ListOfEffects;
        protected Dictionary<String, List<Effect>> DictionaryofPriceEffects;
        protected Random rand;
        public Location(string thisName, string thisType){
            name = thisName;
            type = thisType;
            listOfNPC = new List<NPC>();
            listOfNPCSellers = new List<NPC>();
            ListOfEffects = new List<Effect>();
            DictionaryofPriceEffects = new Dictionary<string, List<Effect>>();
            rand = new Random();
            TimeSystem.getInstance().addLocationtoTimeSystem(this);
        }
        public string getName(){
            return this.name;
        }
        public string getType(){
            return this.type;
        }
        public void addNPC(NPC newNPC){
            if(sellerNames.Contains(newNPC.getType())){
                listOfNPCSellers.Add(newNPC);
            }
            listOfNPC.Add(newNPC);
        }
        public void deleteNPC(NPC thisNPC){
            listOfNPC.Remove(thisNPC);
        }
        public List<NPC> getNPC(){
            return listOfNPC;
        }
        public NPC findRandomNPCType(string npcType){
            List<int> correctNPC = new List<int>();
            for(int i = 0; i < listOfNPC.Count; ++i){
                if(listOfNPC[i].getType() == npcType){
                    correctNPC.Add(i);
                }
            }
            int randNPCId = rand.Next() % correctNPC.Count;
            return listOfNPC[correctNPC[randNPCId]];
        }
        public void proveEffects(){
            for(int i = ListOfEffects.Count - 1; i >= 0; --i){
                if(ListOfEffects[i].provDone()){
                    TimeSystem.getInstance().writeLog(ListOfEffects[i].getName() + " перестаёт оказывать эффект на " + name);
                    if(ListOfEffects[i].getEffectType() == PriceEffectType){
                        DictionaryofPriceEffects[ListOfEffects[i].getOwner()].Remove(ListOfEffects[i]);
                    }
                    ListOfEffects.RemoveAt(i);
                }
            }
        }
        public void addEffect(Effect thisEffect){
            ListOfEffects.Add(thisEffect);
            if(thisEffect.getEffectType() == PriceEffectType){
                if(!DictionaryofPriceEffects.ContainsKey(thisEffect.getOwner())){
                    DictionaryofPriceEffects.Add(thisEffect.getOwner(), new List<Effect>());
                }
                DictionaryofPriceEffects[thisEffect.getOwner()].Add(thisEffect);
            }
        }
        public Dictionary<String, List<Effect>> getDictionaryPrice(){
            return DictionaryofPriceEffects;
        }
        public void makeTick(){
            proveEffects();
        }
        public bool NPCBuyFood(NPC thisNPC){
            for(int i = 0; i < listOfNPCSellers.Count; ++i){
                if(listOfNPCSellers[i].buyFood(thisNPC)){
                    return true;
                }
            }
            return false;
        }
    }
}