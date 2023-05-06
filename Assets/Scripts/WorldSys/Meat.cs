using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Meat : Product{
        public Meat(string subtype, int maincost, int wisdomlevel) : base(NormalMeatName, subtype, 100, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalMeat : Meat{
        public NormalMeat() : base(NormalMeatName, 100, 0){
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
    public class GoldenMeat : Meat{
        public GoldenMeat() : base(GoldenMeatName, 300, 20){
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
    public class BadMeat : Meat{
        public BadMeat() : base(BadMeatName, 50, 10){
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