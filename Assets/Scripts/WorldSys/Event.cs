using System;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Event
    {
        protected string name;
        protected string location;
        protected string text;
        protected int timeToStart;
        protected int startTime;
        protected bool used;
        protected List<Effect> ListOfEffects;
        protected List<string> ListOfRumors;
        public Event(string thisName, string thisLocation, string thisText, int thisTimeToStart, List<Effect> thisListOfEffects, List<String> thisListOfRumors)
        {
            name = thisName;
            location = thisLocation;
            text = thisText;
            timeToStart = thisTimeToStart;
            startTime = thisTimeToStart;
            used = false;
            ListOfEffects = thisListOfEffects;
            ListOfRumors = thisListOfRumors;
        }
        public bool Start()
        {
            if (timeToStart > 0)
            {
                --timeToStart;
                used = true;
                return false;
            }
            else
            {
                used = false;
                timeToStart = startTime;
                return true;
            }
        }
        public List<String> GetRumors()
        {
            return ListOfRumors;
        }
        public List<Effect> GetEffects()
        {
            return ListOfEffects;
        }
        public string GetName()
        {
            return name;
        }
        public string GetText()
        {
            return text;
        }
        public string GetLocation()
        {
            return location;
        }
    }
}