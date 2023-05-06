using System;
using System.Collections.Generic;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    public static class WorldSystem
    {
        private static TimeSystem timeSystem;
        static void Main(string[] args)
        {
            timeSystem = TimeSystem.GetInstance();
            // Location newlocation = new Location("Деревня", VillageName);
            // newlocation = new Location("Город", TownName);
            NPC newNPC = new Fermer("Марк", "Деревня", new List<String>() { "Дом1", "Улица", "Работа1", "Дом1" });
            newNPC = new Millworker("Рудольф", "Деревня", new List<String>() { "Дом2", "Улица", "Работа2", "Дом2" });
            newNPC = new Fermer("Олег", "Деревня", new List<String>() { "Дом3", "Улица", "Работа1", "Дом3" });
            newNPC = new Baker("Андрей", "Город", new List<String>() { "Дом4", "Улица2", "Работа4", "Дом4" });
            newNPC = new Elder("Александро", "Деревня", new List<String>() { "Дом5", "Улица", "Работа5", "Дом5" });
            newNPC = new Trader("Джон", new List<string>() { "Деревня", "Город" }, new List<List<string>>() { new List<string>() { ElderProfessionName, FermerProfessionName, MillworkerProfessionName }, new List<string>() { BakerProfessionName } }, 10);
            newNPC.AddEffect(new PriceEffect("Рождение ребёнка", 2, 100, "All"));
            timeSystem.StartFirstEvent();
            for (int i = 0; i < 15; ++i)
            {
                TimeSystem.GetInstance().WriteLog("Идёт тик " + i.ToString());
                Console.WriteLine("Идёт тик " + i.ToString());
                timeSystem.MakeTicks(1);
            }
            TimeSystem.GetInstance().EndLog();
        }

    }
}