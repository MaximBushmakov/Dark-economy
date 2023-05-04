using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    public class Millet : Product{
        public Millet(string subtype, int maincost, int wisdomlevel) : base(NormalMilletName, subtype, 100, maincost, wisdomlevel){
        }
    }
    public class NormalMillet : Millet{
        public NormalMillet() : base(NormalMilletName, 100, 0){
        }
        public override void makeTick(){
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
    public class GoldenMillet : Millet{
        public GoldenMillet() : base(GoldenMilletName, 300, 20){
        }
        public override void makeTick(){
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
    public class BadMillet : Millet{
        public BadMillet() : base(BadMilletName, 50, 10){
        }
        public override void makeTick(){
            ++ticks;
            switch(ticks){
                case > 40:
                    quality = 0;
                    break;
            }
        }
    }
}