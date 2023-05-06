using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Pottery : Product{
        public Pottery(string subtype, int maincost, int wisdomlevel) : base(NormalPotteryName, subtype, 100, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalPottery : Pottery{
        public NormalPottery() : base(NormalPotteryName, 100, 0){
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
    public class GoldenPottery : Pottery{
        public GoldenPottery() : base(GoldenPotteryName, 300, 20){
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
    public class BadPottery : Pottery{
        public BadPottery() : base(BadPotteryName, 50, 10){
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