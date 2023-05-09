using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Horseshoe : Product{
        public Horseshoe(string subtype, int maincost, int wisdomlevel) : base(NormalHorseshoeName, subtype, 320, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalHorseshoe : Horseshoe{
        public NormalHorseshoe() : base(NormalHorseshoeName, 320, 0){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 80:
                    quality = 0;
                    break;
                case > 70:
                    quality = 1;
                    break;
                case > 60:
                    quality = 2;
                    break;
            }
        }
    }
    [Serializable]
    public class GoldenHorseshoe : Horseshoe{
        public GoldenHorseshoe() : base(GoldenHorseshoeName, 530, 25){
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
    public class BadHorseshoe : Horseshoe{
        public BadHorseshoe() : base(BadHorseshoeName, 110, 11){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 80:
                    quality = 0;
                    break;
                case > 30:
                    quality = 2;
                    break;
            }
        }
    }
}