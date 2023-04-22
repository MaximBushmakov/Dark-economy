using System;
using System.Collections.Generic;

namespace WorldSystem
{
    class Location{
        private List<Effect> ListOfEffects;
        protected string name;
        private List<NPC> listOfNPC;
        public Location(string thisName){
            name = thisName;
            listOfNPC = new List<NPC>();
            ListOfEffects = new List<Effect>();
            TimeSystem.getInstance().addLocationtoTimeSystem(this);
        }
        public string getName(){
            return this.name;
        }
        public void addNPC(NPC newNPC){
            listOfNPC.Add(newNPC);
        }
        public void proveEffects(){
            for(int i = ListOfEffects.Count - 1; i >= 0; --i){
                if(ListOfEffects[i].provDone()){
                    Console.WriteLine(ListOfEffects[i].getName() + " перестаёт оказывать эффект на " + name);
                    ListOfEffects.RemoveAt(i);
                }
            }
        }
    }
}