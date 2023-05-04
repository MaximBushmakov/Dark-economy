using System;
using System.Collections.Generic;

namespace WorldSystem
{
    public class Product{
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
            TimeSystem.GetInstance().AddProducttoTimeSystem(this);
        }
        public string GetVisibleType(int wisdom){
            if(wisdom < wisdomLevel){
                return mainType;
            }
            return subType;
        }
        public string GetMainType(){
            return mainType;
        }
        public string GetSubType(){
            return subType;
        }
        public virtual void MakeTick(){
            ticks += 1;
        }
        public int GetQuality(){
            return this.quality;
        }
        public int GetCost(int wisdom){
            if(wisdom < wisdomLevel){
                return basicCost;
            }
            return mainCost;
        }
        public void DeleteThis(){
            quality = 0;
        }
    }
}