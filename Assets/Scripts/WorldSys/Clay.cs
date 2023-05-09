using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Clay : Product{
        public Clay(string subtype, int maincost, int wisdomlevel) : base(NormalClayName, subtype, 120, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalClay : Clay{
        public NormalClay() : base(NormalClayName, 120, 0){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 100:
                    quality = 0;
                    break;
                case > 50:
                    quality = 1;
                    break;
            }
        }
    }
    [Serializable]
    public class GoldenClay : Clay{
        public GoldenClay() : base(GoldenClayName, 220, 50){
        }
        public override void MakeTick(){
            ticks++;
            switch(ticks){
                case > 700:
                    quality = 0;
                    break;
            }
        }
    }
    [Serializable]
    public class BadClay : Clay{
        public BadClay() : base(BadClayName, 70, 20){
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