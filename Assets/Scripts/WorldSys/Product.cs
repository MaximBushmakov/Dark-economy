using System;

namespace WorldSystem
{
    class Product{
        protected string mainType;
        protected string subType;
        protected int mainCost;
        protected int basicCost;
        protected int quality;
        protected int ticks;
        protected int wisdomLevel;
        public Product(string type, string subtype, int basiccost, int maincost, int wisdomlevel){
            mainType = type;
            subType = subtype;
            mainCost = maincost;
            basicCost = basiccost;
            quality = 3;
            ticks = 0;
            wisdomLevel = wisdomlevel;
            TimeSystem.getInstance().addProducttoTimeSystem(this);
        }
        public string returnType(int wisdom){
            if(wisdom < wisdomLevel){
                return mainType;
            }
            return subType;
        }
        public string returnMainType(){
            return mainType;
        }
        public string returnSubType(){
            return subType;
        }
        public virtual void makeTicks(int n){
            ticks += n;
        }
        public int returnQuality(){
            return this.quality;
        }
        public int returnCost(int wisdom){
            if(wisdom < wisdomLevel){
                return basicCost;
            }
            return mainCost;
        }
    }
}