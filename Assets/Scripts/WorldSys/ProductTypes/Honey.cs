using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Honey : Product{
        public Honey(string subtype, int maincost, int wisdomlevel) : base(NormalHoneyName, subtype, 270, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalHoney : Honey{
        public NormalHoney() : base(NormalHoneyName, 270, 0){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 1000:
                    quality = 0;
                    break;
            }
        }
    }
    [Serializable]
    public class GoldenHoney : Honey{
        public GoldenHoney() : base(GoldenHoneyName, 570, 80){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 1000:
                    quality = 0;
                    break;
            }
        }
    }
    [Serializable]
    public class BadHoney : Honey{
        public BadHoney() : base(BadHoneyName, 10, 50){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 10:
                    quality = 0;
                    break;
            }
        }
    }
}