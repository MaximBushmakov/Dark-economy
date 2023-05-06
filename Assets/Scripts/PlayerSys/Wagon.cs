using System;

namespace PlayerSystem
{
    [Serializable]
    public class Wagon
    {
        public string Name { get; }
        public int Capacity { get; }
        public float Speed { get; }


        public Wagon(string name, int capacity, float speed)
        {
            Name = name;
            Capacity = capacity;
            Speed = speed;
        }
    }

    public static class WagonData
    {
        public static Wagon Donkey;

        static WagonData()
        {
            Donkey = new("Donkey", 10, 1.0f);
        }
    }
}