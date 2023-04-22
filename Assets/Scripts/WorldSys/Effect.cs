using System;

namespace WorldSystem
{
    class Effect{
        string name;
        string type;
        int lifeTime;
        int ticks;
        public Effect(string thisName, string thisType, int thisLifeTime){
            name = thisName;
            type = thisType;
            lifeTime = thisLifeTime;
            ticks = 0;
            TimeSystem.getInstance().addEffecttoTimeSystem(this);
        }
        public string getName(){
            return name;
        }
        public bool provDone(){
            return(ticks >= lifeTime);
        }
        public void makeTick(){
            ++ticks;
        }
    }
    class PriceEffect : Effect{
        private int effectBaf;
        private string productType;
        public PriceEffect(string thisName, int thisLifeTime, int thisEffectBaf, string thisproductType) : base(thisName, "Price", thisLifeTime){
            effectBaf = thisEffectBaf;
            productType = thisproductType;
        }
    }
}