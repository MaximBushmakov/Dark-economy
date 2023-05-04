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
    }
    public class LocalEvent{
        protected string name;
        protected string text;
        protected string type;
        protected List<int> ListOfAnswerId;
        protected List<LocalEventEffect> ListofEffects;
        public LocalEvent(string thisName, string thisText, string thisType,  List<int> thisListOfAnswerId, List<LocalEventEffect> thisListOfEffects){
            name = thisName;
            text = thisText;
            type = thisType;
            ListOfAnswerId = thisListOfAnswerId;
            ListofEffects = thisListOfEffects;
        }
        public LocalEvent makeChose(int id, string type){
            return AllLocalEvents.getInstance().getEvent(id, type);
        }
    }
}