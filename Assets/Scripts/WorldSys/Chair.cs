using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Chair : Product{
        public Chair(string subtype, int maincost, int wisdomlevel) : base(NormalChairName, subtype, 100, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalChair : Chair{
        public NormalChair() : base(NormalChairName, 100, 0){
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
    public class GoldenChair : Chair{
        public GoldenChair() : base(GoldenChairName, 300, 20){
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
    public class BadChair : Chair{
        public BadChair() : base(BadChairName, 50, 10){
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