using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class DriedMeat : Product{
        public DriedMeat(string subtype, int maincost, int wisdomlevel) : base(NormalDriedMeatName, subtype, 100, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalDriedMeat : Meat{
        public NormalDriedMeat() : base(NormalDriedMeatName, 100, 0){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 15:
                    quality = 0;
                    break;
                case > 10:
                    quality = 1;
                    break;
                case > 5:
                    quality = 2;
                    break;
            }
        }
    }
    [Serializable]
    public class GoldenDriedMeat : Meat{
        public GoldenDriedMeat() : base(GoldenDriedMeatName, 300, 20){
        }
        public override void MakeTick(){
            ticks++;
            switch(ticks){
                case > 20:
                    quality = 0;
                    break;
                case > 15:
                    quality = 1;
                    break;
                case > 10:
                    quality = 2;
                    break;
            }
        }
    }
    [Serializable]
    public class BadDriedMeat : Meat{
        public BadDriedMeat() : base(BadDriedMeatName, 50, 10){
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