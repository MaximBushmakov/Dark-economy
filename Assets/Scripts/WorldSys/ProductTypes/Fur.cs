using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Fur : Product{
        public Fur(string subtype, int maincost, int wisdomlevel) : base(NormalFurName, subtype, 250, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalFur : Fur{
        public NormalFur() : base(NormalFurName, 250, 0){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 35:
                    quality = 0;
                    break;
                case > 25:
                    quality = 1;
                    break;
                case > 15:
                    quality = 2;
                    break;
            }
        }
    }
    [Serializable]
    public class GoldenFur : Fur{
        public GoldenFur() : base(GoldenFurName, 450, 20){
        }
        public override void MakeTick(){
            ticks++;
            switch(ticks){
                case > 90:
                    quality = 0;
                    break;
                case > 70:
                    quality = 1;
                    break;
                case > 50:
                    quality = 2;
                    break;
            }
        }
    }
    [Serializable]
    public class BadFur : Fur{
        public BadFur() : base(BadFurName, 150, 10){
        }
        public override void MakeTick(){
            ticks++;
            switch(ticks){
                case > 20:
                    quality = 0;
                    break;
                case > 15:
                    quality = 2;
                    break;
            }
        }
    }
}