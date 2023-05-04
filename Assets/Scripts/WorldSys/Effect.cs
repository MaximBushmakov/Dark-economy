using System;
using System.Collections.Generic;

namespace WorldSystem
{
    class Effect{
        string name;
        string type;
        int lifeTime;
        int ticks;
        string owner;
        private int effectBaf;
        public Effect(string thisName, string thisType, string thisOwner, int thisEffectBaf, int thisLifeTime){
            name = thisName;
            type = thisType;
            lifeTime = thisLifeTime;
            ticks = 0;
            owner = thisOwner;
            effectBaf = thisEffectBaf;
            TimeSystem.getInstance().addEffecttoTimeSystem(this);
        }
        public string getName(){
            return name;
        }
        public int getEffectBaf(){
            return effectBaf;
        }
        public string getOwner(){
            return owner;
        }
        public String getEffectType(){
            return type;
        }
        public bool provDone(){
            return(ticks >= lifeTime);
        }
        public void makeTick(){
            ++ticks;
        }
    }
    class PriceEffect : Effect{
        public PriceEffect(string thisName, int thisLifeTime, int thisEffectBaf, string thisproductType) : base(thisName, "Price", thisproductType, thisEffectBaf, thisLifeTime){
        }
    }
}