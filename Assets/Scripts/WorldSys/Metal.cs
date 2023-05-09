using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Metal : Product{
        public Metal(string subtype, int maincost, int wisdomlevel) : base(NormalMetalName, subtype, 300, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalMetal : Metal{
        public NormalMetal() : base(NormalMetalName, 300, 0){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 100:
                    quality = 0;
                    break;
                case > 90:
                    quality = 1;
                    break;
                case > 80:
                    quality = 2;
                    break;
            }
        }
    }
    [Serializable]
    public class GoldenMetal : Metal{
        public GoldenMetal() : base(GoldenMetalName, 500, 30){
        }
        public override void MakeTick(){
            ticks++;
            switch(ticks){
                case > 1000:
                    quality = 0;
                    break;
            }
        }
    }
    [Serializable]
    public class BadMetal : Metal{
        public BadMetal() : base(BadMetalName, 100, 10){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 100:
                    quality = 0;
                    break;
                case > 50:
                    quality = 2;
                    break;
            }
        }
    }
}