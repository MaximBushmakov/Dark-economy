using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public static class GameData
    {
        private static readonly Player _player;
        private static readonly List<string> _notes;
        private static string _locationName;

        public static Player GetPlayer()
        {
            return _player;
        }

        public static string GetLocationName()
        {
            return _locationName;
        }

        public static void SetLocationName(string locationName)
        {
            _locationName = locationName;
        }

        static GameData()
        {
            _player = new Player();
            _notes = new List<string>();
        }
    }
}