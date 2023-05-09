using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Pottery : Product{
        public Pottery(string subtype, int maincost, int wisdomlevel) : base(NormalPotteryName, subtype, 170, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalPottery : Pottery{
        public NormalPottery() : base(NormalPotteryName, 170, 0){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 200:
                    quality = 0;
                    break;
                case > 150:
                    quality = 1;
                    break;
            }
        }
    }
    [Serializable]
    public class GoldenPottery : Pottery{
        public GoldenPottery() : base(GoldenPotteryName, 270, 60){
        }
        public override void MakeTick(){
             ticks++;
            switch(ticks){
                case > 900:
                    quality = 0;
                    break;
            }
        }
    }
    [Serializable]
    public class BadPottery : Pottery{
        public BadPottery() : base(BadPotteryName, 100, 23){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 10:
                    quality = 0;
                    break;
                case > 5:
                    quality = 1;
                    break;
            }
        }
    }
}