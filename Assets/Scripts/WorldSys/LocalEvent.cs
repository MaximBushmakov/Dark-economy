using System;
using System.Collections.Generic;

namespace WorldSystem
{
    public class LocalEventEffect{
        protected string type;
        protected int baf;
        public LocalEventEffect(string thisType, int thisBaf){
            type = thisType;
            baf = thisBaf;
        }
        public string GetEffectType(){
            return type;
        }
        public int GetBaf(){
            return baf;
        }
    }
    public class LocalEvent{
        protected string name;
        protected string text;
        protected string type;
        protected List<int> ListOfAnswerId;
        protected List<LocalEventEffect> ListofEffects;
        public LocalEvent(string thisName, string thisType, string thisText,  List<int> thisListOfAnswerId, List<LocalEventEffect> thisListOfEffects){
            name = thisName;
            type = thisType;
            text = thisText;
            ListOfAnswerId = thisListOfAnswerId;
            ListofEffects = thisListOfEffects;
        }
        public string  GetName(){
            return name;
        }
        public string  GetEventType(){
            return type;
        }
        public LocalEvent MakeChose(int id){
            return AllLocalEvents.GetInstance().GetEvent(id, type);
        }
        public List<int> GetAnswers(){
            return ListOfAnswerId;
        }
        public List<LocalEventEffect> GetEffects(){
            return ListofEffects;
        }
    }
}