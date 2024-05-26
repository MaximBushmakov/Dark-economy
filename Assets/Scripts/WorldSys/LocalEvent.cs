using System;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class LocalEventEffect
    {
        private string type;
        private int baf;
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
        private string name;
        private string text;
        private string type;
        private List<int> ListOfAnswerId;
        private List<string> ListOfAnswers;
        private List<LocalEventEffect> ListOfEffects;

        public LocalEvent(string thisName, string thisType, string thisText, List<int> thisListOfAnswerId, List<string> thisListOfAnswers, List<LocalEventEffect> thisListOfEffects)
        {
            name = thisName;
            type = thisType;
            text = thisText;
            ListOfAnswers = thisListOfAnswers;
            ListOfAnswerId = thisListOfAnswerId;
            ListOfEffects = thisListOfEffects;
        }

        public string GetName() => name;
        public string GetText() => text;
        public string GetEventType() => type;
        public List<int> GetAnswerId() => ListOfAnswerId;
        public List<string> GetAnswers() => ListOfAnswers;
        public List<LocalEventEffect> GetEffects() => ListOfEffects;

        public LocalEvent MakeChose(int id) => AllLocalEvents.GetInstance().GetEvent(id, type);
    }
}