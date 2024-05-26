using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    public static class LocationData
    {
        private static ReadOnlyDictionary<string, Location> _locations;
        public static ReadOnlyDictionary<string, Location> Locations { get => _locations; }

        public static void Initialize(List<Location> locationsList)
        {
            _locations = new ReadOnlyDictionary<string, Location>(locationsList
                .ToDictionary(loc => loc.GetName(), loc => loc));
        }

        public static void Initialize()
        {
            string jsonFilePath = "Assets/Scripts/WorldSys/locations.json";
            var locationsList = LoadLocationsFromJson(jsonFilePath);
            _locations = new ReadOnlyDictionary<string, Location>(locationsList.ToDictionary(loc => loc.GetName(), loc => loc));
        }

        private static List<Location> LoadLocationsFromJson(string jsonFilePath)
        {
            string json = File.ReadAllText(jsonFilePath);
            var locationDtos = JsonConvert.DeserializeObject<List<LocationDto>>(json);
            return locationDtos.Select(dto => new Location(dto.Name, dto.GlobalName, dto.SubLocations)).ToList();
        }
    }

    public class LocationDto
    {
        public string Name { get; set; }
        public string GlobalName { get; set; }
        public List<string> SubLocations { get; set; }
    }
}