using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using WorldSystem;

namespace PlayerSystem
{
    public static class GameData
    {
        public static readonly Player Player;
        private static readonly List<string> _notes;


        static GameData()
        {
            Player = new Player();
            _notes = new List<string>();
        }

        public static void NewGame()
        {
            TimeSystem timeSystem = TimeSystem.GetInstance();
            LocationData.Initialize();
            NPCData.Initialize();
            timeSystem.StartFirstEvent();
        }

        public static void Save()
        {
            Directory.CreateDirectory(Path.GetDirectoryName("/Games/Dark economy/Save/Locations.dat"));
            FileStream LocationFS = new("/Games/Dark economy/Save/Locations.dat", FileMode.Create);
            BinaryFormatter formatter = new();
            try
            {
                formatter.Serialize(LocationFS, LocationData.Locations);
            }
            catch (SerializationException e)
            {
                Debug.Log("Location serialization error: " + e.Message);
                throw;
            }
            finally
            {
                LocationFS.Close();
            }
        }

        public static void Load()
        {
            FileStream LocationFS = new("/Save/Locations.dat", FileMode.Open);
            BinaryFormatter formatter = new();
            try
            {
                LocationData.Initialize(formatter.Deserialize(LocationFS) as List<Location>);
                Debug.Log(LocationData.Locations);
            }
            catch (SerializationException e)
            {
                Debug.Log("Location serialization error: " + e.Message);
                throw;
            }
            finally
            {
                LocationFS.Close();
            }
        }
    }
}