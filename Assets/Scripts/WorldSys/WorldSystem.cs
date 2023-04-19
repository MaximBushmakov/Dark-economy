using System;

namespace WorldSystem
{
    class WorldSystem{
        private static TimeSystem timeSystem;
        static void Main(string[] args){
            timeSystem = TimeSystem.getInstance();
            NPC newNPC = new Fermer("Mark", 0, 0);
            newNPC = new Fermer("Oleg", 0, 0);
            for(int i = 0; i < 50; ++i){
                Console.WriteLine("Идёт тик " + i.ToString());
                timeSystem.makeTicks(1);
            }
        }
    }
}