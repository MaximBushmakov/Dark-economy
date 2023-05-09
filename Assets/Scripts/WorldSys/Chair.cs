using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Chair : Product{
        public Chair(string subtype, int maincost, int wisdomlevel) : base(NormalChairName, subtype, 350, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalChair : Chair{
        public NormalChair() : base(NormalChairName, 350, 0){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 50:
                    quality = 0;
                    break;
                case > 40:
                    quality = 1;
                    break;
                case > 30:
                    quality = 2;
                    break;
            }
        }
    }
    [Serializable]
    public class GoldenChair : Chair{
        public GoldenChair() : base(GoldenChairName, 1000, 40){
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
        public BadChair() : base(BadChairName, 150, 20){
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