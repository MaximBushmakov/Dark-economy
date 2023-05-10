using System;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class LocalEventEffect
    {
        protected string type;
        protected int baf;
        public LocalEventEffect(string thisType, int thisBaf)
        {
            type = thisType;
            baf = thisBaf;
        }
        public string GetEffectType()
        {
            return type;
        }
        public int GetBaf()
        {
            return baf;
        }
    }
    [Serializable]
    public class LocalEvent
    {
        protected string name;
        protected string text;
        protected string type;
        protected List<int> ListOfAnswerId;
        protected List<string> ListOfAnswers;
        protected List<LocalEventEffect> ListOfEffects;
        public LocalEvent(string thisName, string thisType, string thisText, List<int> thisListOfAnswerId, List<String> thisListOfAnswers, List<LocalEventEffect> thisListOfEffects)
        {
            name = thisName;
            type = thisType;
            text = thisText;
            ListOfAnswers = thisListOfAnswers;
            ListOfAnswerId = thisListOfAnswerId;
            ListOfEffects = thisListOfEffects;
        }
        public string GetName()
        {
            return name;
        }
        public string GetText()
        {
            return text;
        }
        public string GetEventType()
        {
            return type;
        }
        public LocalEvent MakeChose(int id)
        {
            return AllLocalEvents.GetInstance().GetEvent(id, type);
        }
        public List<int> GetAnswerId()
        {
            return ListOfAnswerId;
        }
        public List<string> GetAnswers()
        {
            return ListOfAnswers;
        }
        public List<LocalEventEffect> GetEffects()
        {
            return ListOfEffects;
        }
    }
}