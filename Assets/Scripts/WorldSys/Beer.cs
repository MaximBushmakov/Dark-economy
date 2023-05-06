using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Beer : Product{
        public Beer(string subtype, int maincost, int wisdomlevel) : base(NormalBeerName, subtype, 5, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalBeer : Beer{
        public NormalBeer() : base(NormalBeerName, 150, 0){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 100:
                    quality = 0;
                    break;
            }
        }
    }
    [Serializable]
    public class GoldenBeer : Beer{
        public GoldenBeer() : base(GoldenBeerName, 450, 25){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 100:
                    quality = 0;
                    break;
            }
        }
    }
    [Serializable]
    public class BadBeer : Beer{
        public BadBeer() : base(BadBeerName, 30, 5){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 100:
                    quality = 0;
                    break;
            }
        }
    }
}


