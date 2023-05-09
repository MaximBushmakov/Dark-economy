using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Wax : Product{
        public Wax(string subtype, int maincost, int wisdomlevel) : base(NormalWaxName, subtype, 150, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalWax : Wax{
        public NormalWax() : base(NormalWaxName, 150, 0){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 1000:
                    quality = 0;
                    break;
            }
        }
    }
    [Serializable]
    public class GoldenWax : Wax{
        public GoldenWax() : base(GoldenWaxName, 350, 45){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 1000:
                    quality = 0;
                    break;
            }
        }
    }
    [Serializable]
    public class BadWax : Wax{
        public BadWax() : base(BadWaxName, 100, 15){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 10:
                    quality = 0;
                    break;
            }
        }
    }
}