using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    public static class LocationData
    {
        public static ReadOnlyDictionary<string, Location> _locations;
        public static ReadOnlyDictionary<string, Location> Locations { get => _locations; }

        public static void Initialize(List<Location> locationsList)
        {
            _locations = new ReadOnlyDictionary<string, Location>(locationsList
                .ToDictionary(loc => loc.GetName(), loc => loc));
        }

        public static void Initialize()
        {
            _locations = new ReadOnlyDictionary<string, Location>(new List<Location>
            {
                new ("Город", TownName, new List<string>
                {
                    "Город",
                    "Дом 1",
                    "Дом 2"
                }),
                new ("Деревня", VillageName, new List<string>
                {
                    "Деревня",
                    "Поле",
                    "Мельница",
                    "Хата 1",
                    "Хата 2",
                    "Хата 3"
                })
            }.ToDictionary(loc => loc.GetName(), loc => loc));
        }
    }
}