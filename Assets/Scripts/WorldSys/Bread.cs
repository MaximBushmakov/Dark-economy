using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    public class Bread : Product{
        public Bread(string subtype, int maincost, int wisdomlevel) : base(NormalBreadName, subtype, 5, maincost, wisdomlevel){
        }
    }
    public class NormalBread : Bread{
        public NormalBread() : base(NormalBreadName, 200, 0){
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
    public class GoldenBread : Bread{
        public GoldenBread() : base(GoldenBreadName, 500, 25){
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
    public class BadBread : Bread{
        public BadBread() : base(BadFlourName, 40, 5){
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
}