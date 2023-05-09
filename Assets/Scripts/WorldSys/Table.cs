using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Table : Product{
        public Table(string subtype, int maincost, int wisdomlevel) : base(NormalTableName, subtype, 550, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalTable : Table{
        public NormalTable() : base(NormalTableName, 550, 0){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 50:
                    quality = 0;
                    break;
                case > 40:
                    quality = 1;
                    break;
                case > 30:
                    quality = 2;
                    break;
            }
        }
    }
    [Serializable]
    public class GoldenTable : Table{
        public GoldenTable() : base(GoldenTableName, 1500, 40){
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
    public class BadTable : Table{
        public BadTable() : base(BadTableName, 200, 20){
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