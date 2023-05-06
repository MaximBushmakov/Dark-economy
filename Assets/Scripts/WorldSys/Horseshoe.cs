using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Horseshoe : Product{
        public Horseshoe(string subtype, int maincost, int wisdomlevel) : base(NormalHorseshoeName, subtype, 100, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalHorseshoe : Horseshoe{
        public NormalHorseshoe() : base(NormalHorseshoeName, 100, 0){
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
    public class GoldenHorseshoe : Horseshoe{
        public GoldenHorseshoe() : base(GoldenHorseshoeName, 300, 20){
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
    public class BadHorseshoe : Horseshoe{
        public BadHorseshoe() : base(BadHorseshoeName, 50, 10){
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