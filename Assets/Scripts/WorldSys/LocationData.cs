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
                    "Пекарня",
                    "Порт",
                    "Плотницкая",
                    "Кузница",
                    "Гончарная",
                    "Мастерская Сапожника",
                    "Таверна",
                    "Храм"
                }),
                new ("Деревня", VillageName, new List<string>
                {
                    "Деревня",
                    "Мельница",
                    "Зал старейшины",
                    "Дом Марка",
                    "Дом Кирилла",
                    "Дом Германа"
                })
            }.ToDictionary(loc => loc.GetName(), loc => loc));
        }
    }
}