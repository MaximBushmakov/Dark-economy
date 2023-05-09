using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Book : Product{
        public Book(string subtype, int maincost, int wisdomlevel) : base(NormalBookName, subtype, 1000, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalBook : Book{
        public NormalBook() : base(NormalBookName, 1000, 0){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 1000:
                    quality = 0;
                    break;
                case > 100:
                    quality = 1;
                    break;
            }
        }
    }
    [Serializable]
    public class GoldenBook : Book{
        public GoldenBook() : base(GoldenBookName, 10000, 100){
        }
        public override void MakeTick(){
            ticks++;
            switch(ticks){
                case > 10000:
                    quality = 0;
                    break;
            }
        }
    }
    [Serializable]
    public class BadBook : Book{
        public BadBook() : base(BadBookName, 100, 70){
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