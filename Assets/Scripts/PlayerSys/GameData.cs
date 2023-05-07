using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using WorldSystem;

namespace PlayerSystem
{
    public static class GameData
    {

        private const string _savePath = "/Games/Dark economy/Save/Save.dat";
        private static Player _player;
        public static Player Player { get => _player; }
        private static TimeSystem timeSystem;
        private static Dictionary<string, string> _notes;
        public static Dictionary<string, string> Notes { get => _notes; }


        static GameData()
        {
            _player = new();
            timeSystem = TimeSystem.GetInstance();
            _notes = new Dictionary<string, string>
            {
                {"Торговля", ""},
                {"Квесты", ""},
                {"Слухи", ""},
                {"Другое", ""}
            };
        }

        public static void NewGame()
        {
            timeSystem = TimeSystem.GetInstance();
            LocationData.Initialize();
            NPCData.Initialize();
            timeSystem.StartFirstEvent();
        }

        public static void Save()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_savePath));
            BinaryFormatter formatter = new();
            FileStream SaveFS = new(_savePath, FileMode.Create); ;
            try
            {
                formatter.Serialize(SaveFS, LocationData.Locations.Values.ToList());
                formatter.Serialize(SaveFS, timeSystem.GetCurrentEvent());
                formatter.Serialize(SaveFS, _player);
                formatter.Serialize(SaveFS, _notes);
            }
            catch (SerializationException e)
            {
                Debug.Log("Save serialization error: " + e.Message);
                throw;
            }
            finally
            {
                SaveFS.Close();
            }
        }

        public static void Load()
        {
            TimeSystem.Reset();
            FileStream SaveFS = new(_savePath, FileMode.Open);
            BinaryFormatter formatter = new();
            try
            {
                timeSystem.Initialize(
                    formatter.Deserialize(SaveFS) as List<Location>,
                    formatter.Deserialize(SaveFS) as WorldSystem.Event);
                _player = formatter.Deserialize(SaveFS) as Player;
                _notes = formatter.Deserialize(SaveFS) as Dictionary<string, string>;
            }
            catch (SerializationException e)
            {
                Debug.Log("Load serialization error: " + e.Message);
                throw;
            }
            finally
            {
                SaveFS.Close();
            }
        }
    }
}