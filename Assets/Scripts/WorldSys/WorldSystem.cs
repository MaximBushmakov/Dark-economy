using System;

namespace WorldSystem
{
    class WorldSystem{
        private static TimeSystem timeSystem;
        static void Main(string[] args){
            timeSystem = TimeSystem.getInstance();
            Location newlocation = new Location("Деревня");
            NPC newNPC = new Fermer("Mark", "Деревня", 0, 0);
            newNPC = new Fermer("Oleg", "Деревня", 0, 0);
            newNPC = new Millworker("Olegus", "Деревня", 0, 0);
            newNPC.addEffect(new PriceEffect("Рождение ребёнка", 2, 10, "All"));
            for(int i = 0; i < 5; ++i){
                Console.WriteLine("Идёт тик " + i.ToString());
                timeSystem.makeTicks(1);
            }
        }
    }
}