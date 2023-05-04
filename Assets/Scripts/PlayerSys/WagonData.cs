namespace PlayerSystem
{
    public static class WagonData
    {
        public static Wagon Donkey;

        static WagonData()
        {
            Donkey = new("Donkey", 10);
        }
    }
}