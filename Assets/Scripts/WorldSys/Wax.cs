using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Wax : Product{
        public Wax(string subtype, int maincost, int wisdomlevel) : base(NormalWaxName, subtype, 100, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalWax : Wax{
        public NormalWax() : base(NormalWaxName, 100, 0){
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
    public class GoldenWax : Wax{
        public GoldenWax() : base(GoldenWaxName, 300, 20){
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
    public class BadWax : Wax{
        public BadWax() : base(BadWaxName, 50, 10){
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