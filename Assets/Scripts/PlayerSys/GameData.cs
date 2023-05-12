using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        public static LocalEvent CurEvent { get; set; } = null;
        public static WorldSystem.Event CurGlobEvent { get; set; } = null;
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
            if (Random.Range(0, 10) == 1)
            {
                timeSystem.AddEvent(
                AllLocalEvents.GetInstance().GetRandomEvent(_player.Luck,
                    LocationData.Locations[_player.Location].GetLocationType())
                );
            }
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
                var answers = e.GetAnswers();
                if (answers.Count == 0)
                {
                    HandleEvent(-1);
                    return;
                }

                Transform message = SceneManager.GetActiveScene().GetRootGameObjects()
                                    .First(obj => obj.name == "Event canvas")
                                    .transform.GetChild(0);
                message.GetChild(1).GetComponent<Text>().text = e.GetText();
                for (int i = 0; i < answers.Count; ++i)
                {
                    message.GetChild(i + 2).GetComponent<Text>().text = answers[i];
                    message.GetChild(i + 2).gameObject.SetActive(true);
                }
                for (int i = answers.Count; i < 3; ++i)
                {
                    message.GetChild(i + 2).gameObject.SetActive(false);
                }
                message.gameObject.SetActive(true);
            }
            else if (CurEvent == null)
            {
                if ((CurGlobEvent = timeSystem.GetActiveEvent()) != null)
                {
                    CurEvent = new(CurGlobEvent.GetName(), null, CurGlobEvent.GetText(),
                            new List<int>(), new List<string>(), new List<LocalEventEffect>());
                    HandleEvent(-1);
                    CurGlobEvent = null;
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }

        public static void HandleEvent(int ans)
        {
            LocalEvent e;
            if (ans == -1)
            {
                e = CurEvent;
            }
            else
            {
                e = AllLocalEvents.GetInstance()
                    .GetEvent(CurEvent.GetAnswerId()[ans], CurEvent.GetEventType());
            }

            Transform canvas = SceneManager.GetActiveScene().GetRootGameObjects()
                    .First(obj => obj.name == "Event canvas")
                    .transform;
            Transform answer = canvas.GetChild(1);
            answer.GetChild(1).GetComponent<Text>().text = e.GetText();

            if (answer.GetChild(2).GetComponent<BoxCollider2D>() == null)
            {
                var collider = answer.GetChild(0).gameObject.AddComponent<BoxCollider2D>();
                collider.size = new(2320, 1200);

                collider = answer.GetChild(2).gameObject.AddComponent<BoxCollider2D>();
                collider.size = new(100, 100);
                collider.isTrigger = true;
            }

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
        }

        public static void UpdateTime(int n)
        {
            for (int i = 0; i < n; ++i)
            {
                ++_time;
                timeSystem.WriteLog("Идёт тик " + _time);
                timeSystem.MakeTicks(1);
            }
            CurEvents = timeSystem.ReadEvents();
            UpdateEvent();
        }

        public static async void NewGame()
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

            timeSystem.AddEvent(AllLocalEvents.GetInstance().GetEvent(0, StoryEventName));

            SceneManager.LoadSceneAsync(Player.Location, LoadSceneMode.Single);
            int curFrame = Time.frameCount + 10;
            while (curFrame >= Time.frameCount)
            {
                await Task.Yield();
            }

            UpdateTime(1);
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
                formatter.Serialize(SaveFS, _time);
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
                _time = (int)formatter.Deserialize(SaveFS);
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