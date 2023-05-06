using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Fur : Product{
        public Fur(string subtype, int maincost, int wisdomlevel) : base(NormalFurName, subtype, 100, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalFur : Fur{
        public NormalFur() : base(NormalFurName, 100, 0){
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
    public class GoldenFur : Fur{
        public GoldenFur() : base(GoldenFurName, 300, 20){
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
    public class BadFur : Fur{
        public BadFur() : base(BadFurName, 50, 10){
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