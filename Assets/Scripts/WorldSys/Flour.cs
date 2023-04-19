using System;

namespace WorldSystem
{
    class Flour : Product{
        public Flour(string subtype, int maincost, int wisdomlevel) : base("Пшено", subtype, 5, maincost, wisdomlevel){
        }
    }
    class NormalFlour : Flour{
        public NormalFlour() : base("Обычная Мука", 15, 0){
        }
        public override void makeTicks(int n){
            ticks += n;
            switch(ticks){
                case > 100:
                    quality = 0;
                    break;
            }
        }
    }
    class GoldenFlour : Flour{
        public GoldenFlour() : base("Золотая Мука", 45, 25){
        }
        public override void makeTicks(int n){
            ticks += n;
            switch(ticks){
                case > 100:
                    quality = 0;
                    break;
            }
        }
    }
    class BadFlour : Flour{
        public BadFlour() : base("Твёрдая мука", 3, 5){
        }
        public override void makeTicks(int n){
            ticks += n;
            switch(ticks){
                case > 100:
                    quality = 0;
                    break;
            }
        }
    }
}