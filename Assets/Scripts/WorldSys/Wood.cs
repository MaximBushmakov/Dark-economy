using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Wood : Product{
        public Wood(string subtype, int maincost, int wisdomlevel) : base(NormalMilletName, subtype, 150, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalWood : Wood{
        public NormalWood() : base(NormalWoodName, 150, 0){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 40:
                    quality = 0;
                    break;
                case > 30:
                    quality = 1;
                    break;
                case > 20:
                    quality = 2;
                    break;
            }
        }
    }
    [Serializable]
    public class GoldenWood : Wood{
        public GoldenWood() : base(GoldenWoodName, 450, 30){
        }
        public override void MakeTick(){
            ticks++;
            switch(ticks){
                case > 50:
                    quality = 0;
                    break;
            }
        }
    }
    [Serializable]
    public class BadWood : Wood{
        public BadWood() : base(BadWoodName, 55, 10){
        }
        public override void MakeTick(){
            ++ticks;
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
}