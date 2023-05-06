using System.Collections.Generic;
using System.Linq;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    public static class LocationData
    {
        // initializing static class upon call
        public static void Initialize()
        {
            return;
        }

        public readonly static Dictionary<string, Location> Locations;
        static LocationData()
        {
            Locations = new List<Location>
            {
                new ("Город", TownName, new List<string>
                {
                    "Улица",
                    "Дом 1",
                    "Дом 2"
                }),
                new ("Деревня", VillageName, new List<string>
                {
                    "Улица",
                    "Поле",
                    "Мельница",
                    "Хата 1",
                    "Хата 2",
                    "Хата 3"
                })
            }.ToDictionary(loc => loc.Name, loc => loc);
        }
    }
}