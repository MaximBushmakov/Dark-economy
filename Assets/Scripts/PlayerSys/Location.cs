using System.Collections.Generic;
using System.Linq;

namespace PlayerSystem
{
    public class Location
    {
        public readonly string Name;
        public readonly List<string> Sublocations;

        public Location(string name, List<string> sublocations)
        {
            Name = name;
            Sublocations = sublocations;
        }

    }
    public static class LocationData
    {
        public static Location
            Town = new("Город", new List<string>
            {
                "",
                "Дом 1",
                "Дом 2"
            }),
            Village = new("Деревня", new List<string>
            {
                "",
                "Хата 1",
                "Хата 2"
            });

        public static Dictionary<string, Location> Locations = new List<Location>
        {
            Town,
            Village
        }.ToDictionary(loc => loc.Name, loc => loc);
    }
}