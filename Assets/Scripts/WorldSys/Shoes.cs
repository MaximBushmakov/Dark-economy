using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Shoes : Product{
        public Shoes(string subtype, int maincost, int wisdomlevel) : base(NormalShoesName, subtype, 270, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalShoes : Shoes{
        public NormalShoes() : base(NormalShoesName, 270, 0){
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
                case > 20:
                    quality = 2;
                    break;
            }
        }
    }
    [Serializable]
    public class GoldenShoes : Shoes{
        public GoldenShoes() : base(GoldenShoesName, 480, 20){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 70:
                    quality = 0;
                    break;
                case > 50:
                    quality = 1;
                    break;
                case > 30:
                    quality = 2;
                    break;
            }
        }
    }
    [Serializable]
    public class BadShoes : Shoes{
        public BadShoes() : base(BadShoesName, 120, 10){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 30:
                    quality = 0;
                    break;
                case > 20:
                    quality = 1;
                    break;
                case > 10:
                    quality = 2;
                    break;
            }
        }
    }
}