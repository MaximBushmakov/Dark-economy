using System;
using System.Runtime.Serialization;

namespace WorldSystem
{
    [Serializable]
    public class Effect
    {
        private string name;
        private string type;
        private int lifeTime;
        private int ticks;
        private string owner;
        private int effectBaf;

        [OnDeserialized]
        private void OnDeserializeMethod(StreamingContext context)
        {
            TimeSystem.GetInstance().AddEffecttoTimeSystem(this);
        }

        public Effect(string thisName, string thisType, string thisOwner, int thisEffectBaf, int thisLifeTime)
        {
            name = thisName;
            type = thisType;
            lifeTime = thisLifeTime;
            ticks = 0;
            owner = thisOwner;
            effectBaf = thisEffectBaf;
            TimeSystem.GetInstance().AddEffecttoTimeSystem(this);
        }
        public string GetName()
        {
            return name;
        }
        public int GetEffectBaf()
        {
            return effectBaf;
        }
        public string GetOwner()
        {
            return owner;
        }
        public string GetEffectType()
        {
            return type;
        }
        public bool ProvDone()
        {
            return ticks >= lifeTime;
        }
        public void MakeTick()
        {
            ++ticks;
        }
    }
    public class PriceEffect : Effect
    {
        public PriceEffect(string thisName, int thisLifeTime, int thisEffectBaf, string thisproductType)
            : base(thisName, "Price", thisproductType, thisEffectBaf, thisLifeTime) { }
    }
}