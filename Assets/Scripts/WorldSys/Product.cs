using System;

namespace WorldSystem
{
    public class Product
    {
        protected string mainType;
        protected string subType;
        protected int mainCost;
        protected int basicCost;
        protected int quality;
        protected int ticks;
        protected int wisdomLevel;
        public Product(string type, string subtype, int basiccost, int maincost, int wisdomlevel)
        {
            mainType = type;
            subType = subtype;
            mainCost = maincost;
            basicCost = basiccost;
            quality = 3;
            ticks = 0;
            wisdomLevel = wisdomlevel;
            TimeSystem.getInstance().addProducttoTimeSystem(this);
        }
        public string getType(int wisdom)
        {
            if (wisdom < wisdomLevel)
            {
                return mainType;
            }
            return subType;
        }
        public string getMainType()
        {
            return mainType;
        }
        public string getSubType()
        {
            return subType;
        }
        public virtual void makeTick()
        {
            ticks += 1;
        }
        public int getQuality()
        {
            return this.quality;
        }
        public int getCost(int wisdom)
        {
            if (wisdom < wisdomLevel)
            {
                return basicCost;
            }
            return mainCost;
        }
        public void deleteThis()
        {
            quality = 0;
        }
    }
}