using System.Collections.Generic;
using System.Linq;

namespace WorldSystem
{
    public class Road
    {
        public readonly string Name;
        public readonly (string origin, string destination) Locations;
        public readonly int TravelTime;
        public readonly int DangerLevel;
        public readonly string Description;

        public Road(string name, (string, string) locations, int travelTime, int dangerLevel, string description)
        {
            Name = name;
            Locations = locations;
            TravelTime = travelTime;
            DangerLevel = dangerLevel;
            Description = description;
        }
    }

    public static class RoadData
    {
        public static Road
            Safe = new("Safe", ("Город", "Деревня"), 3, 0,
                "Safe road"),
            Unsafe = new("Unsafe", ("Город", "Деревня"), 2, 1,
                "Not so safe road"),
            Dangerous = new("Dangerous", ("Город", "Деревня"), 1, 2,
                "Very dangerous road");
        private static readonly List<Road> RoadsList = new()
        {
            Safe,
            Unsafe,
            Dangerous
        };
        public static readonly Dictionary<string, Road> Roads =
            RoadsList.ToDictionary(road => road.Name, road => road);

        static public int GetSafeRoadTime(string origin, string destination)
        {
            return (from road in RoadsList
                    where
                       road.Locations.origin == origin && road.Locations.destination == destination ||
                       road.Locations.origin == destination && road.Locations.destination == origin
                    select road)
                    .Aggregate((min, next) => min.DangerLevel > next.DangerLevel ? next : min)
                    .TravelTime;
        }
    }
}