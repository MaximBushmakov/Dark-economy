using System;
using System.Collections.Generic;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    [Serializable]
    public class Flour : Product
    {
        public Flour(string subtype, int maincost, int wisdomlevel) : base(NormalFlourName, subtype, 5, maincost, wisdomlevel)
        {
        }
    }
    [Serializable]
    public class NormalFlour : Flour
    {
        public NormalFlour() : base(NormalFlourName, 150, 0)
        {
        }
        public override void MakeTick()
        {
            ++ticks;
            switch (ticks)
            {
                case > 100:
                    quality = 0;
                    break;
            }
        }
    }
    [Serializable]
    public class GoldenFlour : Flour
    {
        public GoldenFlour() : base(GoldenFlourName, 450, 25)
        {
        }
        public override void MakeTick()
        {
            ++ticks;
            switch (ticks)
            {
                case > 100:
                    quality = 0;
                    break;
            }
        }
    }
    [Serializable]
    public class BadFlour : Flour
    {
        public BadFlour() : base(BadFlourName, 30, 5)
        {
        }
        public override void MakeTick()
        {
            ++ticks;
            switch (ticks)
            {
                case > 100:
                    quality = 0;
                    break;
            }
        }
    }
}


