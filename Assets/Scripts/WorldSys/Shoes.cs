using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Shoes : Product{
        public Shoes(string subtype, int maincost, int wisdomlevel) : base(NormalShoesName, subtype, 100, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalShoes : Shoes{
        public NormalShoes() : base(NormalShoesName, 100, 0){
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
    public class GoldenShoes : Shoes{
        public GoldenShoes() : base(GoldenShoesName, 300, 20){
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
    public class BadShoes : Shoes{
        public BadShoes() : base(BadMilletName, 50, 10){
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