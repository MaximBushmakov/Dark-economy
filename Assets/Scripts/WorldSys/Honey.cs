using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Honey : Product{
        public Honey(string subtype, int maincost, int wisdomlevel) : base(NormalHoneyName, subtype, 100, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalHoney : Honey{
        public NormalHoney() : base(NormalHoneyName, 100, 0){
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
    public class GoldenHoney : Honey{
        public GoldenHoney() : base(GoldenHoneyName, 300, 20){
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
    public class BadHoney : Honey{
        public BadHoney() : base(BadHoneyName, 50, 10){
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