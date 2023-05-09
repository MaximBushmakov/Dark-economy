using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Tool : Product{
        public Tool(string subtype, int maincost, int wisdomlevel) : base(NormalToolName, subtype, 700, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalTool : Tool{
        public NormalTool() : base(NormalToolName, 700, 0){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 105:
                    quality = 0;
                    break;
                case > 95:
                    quality = 1;
                    break;
                case > 85:
                    quality = 2;
                    break;
            }
        }
    }
    [Serializable]
    public class GoldenTool : Tool{
        public GoldenTool() : base(GoldenToolName, 1300, 32){
        }
        public override void MakeTick(){
            ticks++;
            switch(ticks){
                case > 1050:
                    quality = 0;
                    break;
            }
        }
    }
    [Serializable]
    public class BadTool : Tool{
        public BadTool() : base(BadToolName, 250, 12){
        }
        public override void MakeTick(){
            ++ticks;
            switch(ticks){
                case > 100:
                    quality = 0;
                    break;
                case > 50:
                    quality = 2;
                    break;
            }
        }
    }
}