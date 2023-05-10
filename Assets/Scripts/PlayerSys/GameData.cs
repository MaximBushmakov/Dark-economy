using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using WorldSystem;
using static WorldSystem.GlobalNames;

namespace PlayerSystem
{
    public static class GameData
    {

        private const string _savePath = "/Games/Dark economy/Save/Save.dat";
        private static Player _player;
        public static Player Player { get => _player; }
        public static NPC CurTrader { get; set; }
        public static Prices CurPrices { get; set; }
        public static string CurRoad { get; set; }
        public static List<LocalEvent> CurEvents { get; set; }
        public static LocalEvent CurEvent { get; set; }
        private static TimeSystem timeSystem;
        private static Dictionary<string, string> _notes;
        public static Dictionary<string, string> Notes { get => _notes; }
        private static int _time;
        public static int Day { get => _time / 4 + 1; }
        public static string TimeOfDay
        {
            get
            {
                return (_time % 4) switch
                {
                    0 => "Утро",
                    1 => "День",
                    2 => "Вечер",
                    3 => "Ночь",
                    _ => throw new System.Exception("Impossible error"),
                };
            }
        }


        static GameData()
        {
            _player = new();
            timeSystem = TimeSystem.GetInstance();
            _notes = new Dictionary<string, string>
            {
                {"Торговля", ""},
                {"Слухи", ""},
                {"Другое", ""}
            };
            _time = 0;
        }

        public static void UpdateTime()
        {
            ++_time;
            timeSystem.WriteLog("Идёт тик " + _time);
            AllLocalEvents.GetInstance().GetRandomEvent(_player.Luck,
                LocationData.Locations[_player.Location].GetLocationType());
            timeSystem.MakeTicks(1);
            CurEvents = timeSystem.ReadEvents();
            UpdateEvent();
        }

        public static void UpdateEvent()
        {
            if (CurEvents.Count > 0)
            {
                LocalEvent e = CurEvents[^1];
                CurEvents.RemoveAt(CurEvents.Count - 1);
                CurEvent = e;
                Transform message = SceneManager.GetActiveScene().GetRootGameObjects()
                    .First(obj => obj.name == "Event canvas")
                    .transform.GetChild(0);
                message.GetChild(1).GetComponent<Text>().text = e.GetText();
                var answers = e.GetAnswers();
                for (int i = 0; i < answers.Count; ++i)
                {
                    message.GetChild(i + 2).GetComponent<Text>().text = answers[i];
                }
                message.gameObject.SetActive(true);
            }
        }

        public static void HandleEvent(int ans)
        {
            Transform canvas = SceneManager.GetActiveScene().GetRootGameObjects()
                    .First(obj => obj.name == "Event canvas")
                    .transform;
            Transform answer = canvas.GetChild(1);

            LocalEvent e = AllLocalEvents.GetInstance()
                .GetEvent(CurEvent.GetAnswerId()[ans], CurEvent.GetEventType());

            answer.GetChild(0).GetComponent<Text>().text = e.GetText();

            foreach (LocalEventEffect effect in e.GetEffects())
            {
                switch (effect.GetEffectType())
                {
                    case KapitalLocalEffectName:
                        _player.Money += effect.GetBaf();
                        break;
                    case ReputationLocalEffectName:
                        _player.Reputation += effect.GetBaf();
                        break;
                    case MinusProductLocalEffectName:
                        _player.GetInventory().DeleteSomeProduct(effect.GetBaf());
                        break;
                    default:
                        _player.GetInventory().AddProductType(effect.GetEffectType(), effect.GetBaf());
                        break;
                }
            }

            canvas.GetChild(0).gameObject.SetActive(false);
            answer.gameObject.SetActive(true);

            UpdateEvent();
        }

        public static void UpdateTime(int n)
        {
            for (int i = 0; i < n; ++i)
            {
                UpdateTime();
            }
        }

        public static void NewGame()
        {
            TimeSystem.Reset();
            LocationData.Initialize();
            NPCData.Initialize();

            _player = new();
            timeSystem = TimeSystem.GetInstance();
            _notes = new Dictionary<string, string>
            {
                {"Торговля", ""},
                {"Слухи", ""},
                {"Другое", ""}
            };
            _time = 0;

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
            if (timeSystem != null)
            {
                TimeSystem.Reset();
            }
            timeSystem = TimeSystem.GetInstance();
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