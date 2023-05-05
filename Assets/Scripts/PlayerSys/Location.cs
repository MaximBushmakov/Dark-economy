using System.Collections.Generic;
using System.IO.Compression;
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
                "main",
                "house 1",
                "house 2"
            }),
            Village = new("Деревня", new List<string>
            {
                "main",
                "hut 1",
                "hut 2"
            });
        private static readonly Location[] LocationsList = {
            Town,
            Village
        };

        public static Dictionary<string, Location> Locations =
            LocationsList.ToDictionary(loc => loc.Name, loc => loc);
    }
}