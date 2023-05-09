using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class DriedMeat : Product{
        public DriedMeat(string subtype, int maincost, int wisdomlevel) : base(NormalDriedMeatName, subtype, 200, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalDriedMeat : Meat{
        public NormalDriedMeat() : base(NormalDriedMeatName, 200, 0){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 40:
                    quality = 0;
                    break;
            }
        }
    }
    [Serializable]
    public class GoldenDriedMeat : Meat{
        public GoldenDriedMeat() : base(GoldenDriedMeatName, 400, 20){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 40:
                    quality = 0;
                    break;
            }
        }
    }
    [Serializable]
    public class BadDriedMeat : Meat{
        public BadDriedMeat() : base(BadDriedMeatName, 100, 10){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 40:
                    quality = 0;
                    break;
            }
        }
    }
}