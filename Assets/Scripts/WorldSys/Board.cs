using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Board : Product{
        public Board(string subtype, int maincost, int wisdomlevel) : base(NormalBoardName, subtype, 5, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalBoard : Bread{
        public NormalBoard() : base(NormalBoardName, 200, 0){
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
    public class GoldenBoard : Board{
        public GoldenBoard() : base(GoldenBoardName, 500, 25){
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
    public class BadBoard : Board{
        public BadBoard() : base(BadBoardName, 40, 5){
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