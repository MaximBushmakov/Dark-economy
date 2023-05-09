using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Skin : Product{
        public Skin(string subtype, int maincost, int wisdomlevel) : base(NormalSkinName, subtype, 200, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalSkin : Skin{
        public NormalSkin() : base(NormalSkinName, 200, 0){
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
    [Serializable]
    public class GoldenSkin : Skin{
        public GoldenSkin() : base(GoldenSkinName, 400, 43){
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
    public class BadSkin : Skin{
        public BadSkin() : base(BadSkinName, 100, 27){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 20:
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
}