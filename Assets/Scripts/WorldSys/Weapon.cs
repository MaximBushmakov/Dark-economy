using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Weapon : Product{
        public Weapon(string subtype, int maincost, int wisdomlevel) : base(NormalWeaponName, subtype, 100, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalWeapon : Weapon{
        public NormalWeapon() : base(NormalWeaponName, 100, 0){
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
    public class GoldenWeapon : Weapon{
        public GoldenWeapon() : base(GoldenWeaponName, 300, 20){
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
    public class BadWeapon : Weapon{
        public BadWeapon() : base(BadWeaponName, 50, 10){
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