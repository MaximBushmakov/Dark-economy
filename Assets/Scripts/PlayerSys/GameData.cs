using System.Collections.Generic;

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
    }
}