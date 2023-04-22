using System;

namespace WorldSystem
{
    class Millet : Product{
        public Millet(string subtype, int maincost, int wisdomlevel) : base("Пшено", subtype, 5, maincost, wisdomlevel){
        }
    }
    class NormalMillet : Millet{
        public NormalMillet() : base("Обычное Пшено", 10, 0){
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
    class GoldenMillet : Millet{
        public GoldenMillet() : base("Золотое Пшено", 30, 20){
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
    class BadMillet : Millet{
        public BadMillet() : base("Пшено для скота", 5, 10){
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