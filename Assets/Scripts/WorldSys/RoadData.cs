using System.Collections.Generic;
using System.Linq;

namespace WorldSystem
{
    public static class RoadData
    {
        public static Road
            Safe,
            Unsafe,
            Dangerous;
        private static readonly List<Road> Roads;

        static RoadData()
        {
            Safe = new(("Город", "Деревня"), 3, 0);
            Unsafe = new(("Город", "Деревня"), 2, 1);
            Dangerous = new(("Город", "Деревня"), 1, 2);
            Roads = new()
            {
                Safe,
                Unsafe,
                Dangerous
            };
        }

        static public int GetSafeRoadTime(string origin, string destination)
        {
            return (from road in Roads
                    where
                       road.GetLocations().origin == origin && road.GetLocations().destination == destination ||
                       road.GetLocations().origin == destination && road.GetLocations().destination == origin
                    select road)
                    .Aggregate((min, next) => min.GetDangerLevel() > next.GetDangerLevel() ? next : min)
                    .GetTravelTime();
        }
    }
}