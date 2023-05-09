using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Candle : Product{
        public Candle(string subtype, int maincost, int wisdomlevel) : base(NormalCandleName, subtype, 300, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalCandle : Candle{
        public NormalCandle() : base(NormalCandleName, 300, 0){
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
    public class GoldenCandle : Candle{
        public GoldenCandle() : base(GoldenCandleName, 750, 20){
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
    public class BadCandle : Candle{
        public BadCandle() : base(BadCandleName, 150, 10){
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