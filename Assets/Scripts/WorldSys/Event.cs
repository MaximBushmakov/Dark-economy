using System;
using System.Collections.Generic;

namespace WorldSystem
{
    public class Event{
        protected string name;
        protected string location;
        protected string text;
        protected int timeToStart;
        protected int startTime;
        protected bool used;
        List<Effect> ListOfEffects;
        List<String> ListOfRumors;
        public Event(string thisName, string thisLocation, string thisText, int thisTimeToStart, List<Effect> thisListOfEffects, List<String> thisListOfRumors){
            name = thisName;
            location = thisLocation;
            text = thisText;
            timeToStart = thisTimeToStart;
            startTime = thisTimeToStart;
            used = false;
            ListOfEffects = thisListOfEffects;
            ListOfRumors = thisListOfRumors;
        }
        public bool start(){
            if(timeToStart > 0){
                --timeToStart;
                used = true;
                return false;
            } else{
                used = false;
                timeToStart = startTime;
                return true;
            }
        }
        public List<String> getRumors(){
            return ListOfRumors;
        }
        public List<Effect> getEffects(){
            return ListOfEffects;
        }
        public string getName(){
            return name;
        }
        public string getText(){
            return text;
        }
        public string getLocation(){
            return location;
        }
    }
}