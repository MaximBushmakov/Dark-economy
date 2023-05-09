using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    [Serializable]
    public class Weapon : Product{
        public Weapon(string subtype, int maincost, int wisdomlevel) : base(NormalWeaponName, subtype, 1000, maincost, wisdomlevel){
        }
    }
    [Serializable]
    public class NormalWeapon : Weapon{
        public NormalWeapon() : base(NormalWeaponName, 1000, 0){
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
    public class GoldenWeapon : Weapon{
        public GoldenWeapon() : base(GoldenWeaponName, 2000, 35){
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
    public class BadWeapon : Weapon{
        public BadWeapon() : base(BadWeaponName, 350, 12){
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