using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    public class Flour : Product{
        public Flour(string subtype, int maincost, int wisdomlevel) : base(NormalFlourName, subtype, 5, maincost, wisdomlevel){
        }
    }
    public class NormalFlour : Flour{
        public NormalFlour() : base(NormalFlourName, 150, 0){
        }
        public override void makeTick(){
            ++ticks;
            switch(ticks){
                case > 100:
                    quality = 0;
                    break;
            }
        }
    }
    public class GoldenFlour : Flour{
        public GoldenFlour() : base(GoldenFlourName, 450, 25){
        }
        public override void makeTick(){
            ++ticks;
            switch(ticks){
                case > 100:
                    quality = 0;
                    break;
            }
        }
    }
    public class BadFlour : Flour{
        public BadFlour() : base(BadFlourName, 30, 5){
        }
        public override void makeTick(){
            ++ticks;
            switch(ticks){
                case > 100:
                    quality = 0;
                    break;
            }
        }
    }
}


