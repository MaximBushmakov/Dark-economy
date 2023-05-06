using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Search;
using WorldSystem;

namespace PlayerSystem
{
    public static class GameData
    {

        private const string _savePath = "/Games/Dark economy/Save/";
        private static Player _player;
        public static Player Player { get; }
        private static TimeSystem timeSystem;
        private static readonly List<string> _notes;


        static GameData()
        {
            _player = new();
            timeSystem = TimeSystem.GetInstance();
            _notes = new();
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
            Directory.CreateDirectory(Path.GetDirectoryName(_savePath + "Save.dat"));
            BinaryFormatter formatter = new();
            FileStream SaveFS = new(_savePath + "Save.dat", FileMode.Create); ;
            try
            {
                formatter.Serialize(SaveFS, LocationData.Locations.Values.ToList());
                formatter.Serialize(SaveFS, timeSystem.GetCurrentEvent());
                formatter.Serialize(SaveFS, _player);
            }
            catch (SerializationException e)
            {
                Debug.Log("Location serialization error: " + e.Message);
                throw;
            }
            finally
            {
                SaveFS.Close();
            }
            Debug.Log("Save complete");
        }

        public static void Load()
        {
            TimeSystem.Reset();
            FileStream SaveFS = new(_savePath + "Save.dat", FileMode.Open);
            BinaryFormatter formatter = new();
            try
            {
                timeSystem.Initialize(
                    formatter.Deserialize(SaveFS) as List<Location>,
                    formatter.Deserialize(SaveFS) as WorldSystem.Event);
                _player = formatter.Deserialize(SaveFS) as Player;
            }
            catch (SerializationException e)
            {
                Debug.Log("Location serialization error: " + e.Message);
                throw;
            }
            finally
            {
                SaveFS.Close();
            }
        }
    }
}