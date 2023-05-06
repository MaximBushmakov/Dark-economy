using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Wood : Product{
        public Wood(string subtype, int maincost, int wisdomlevel) : base(NormalMilletName, subtype, 100, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalWood : Wood{
        public NormalWood() : base(NormalWoodName, 100, 0){
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
    public class GoldenWood : Wood{
        public GoldenWood() : base(GoldenWoodName, 300, 20){
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
    public class BadWood : Wood{
        public BadWood() : base(BadWoodName, 50, 10){
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