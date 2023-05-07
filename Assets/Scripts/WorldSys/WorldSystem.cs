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
            LocationData.Initialize();
            NPCData.Initialize();
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