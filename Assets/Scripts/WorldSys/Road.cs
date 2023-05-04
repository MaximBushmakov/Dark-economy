using System.Collections.Generic;
using System.Dynamic;

namespace WorldSystem
{
    public class Road
    {
        private (string, string) _locations;
        private readonly int _travelTime;
        private readonly int _dangerLevel;

        public Road((string, string) locations, int travelTime, int dangerLevel)
        {
            _locations = locations;
            _travelTime = travelTime;
            _dangerLevel = dangerLevel;
        }

        public (string origin, string destination) GetLocations()
        {
            return _locations;
        }

        public int GetDangerLevel()
        {
            return _dangerLevel;
        }

        public int GetTravelTime()
        {
            return _travelTime;
        }


    }
}