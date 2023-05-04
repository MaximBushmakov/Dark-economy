namespace PlayerSystem
{
    public class Wagon
    {
        private readonly string _name;
        private readonly int _capacity;

        public Wagon(string name, int capacity)
        {
            _name = name;
            _capacity = capacity;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetCapacity()
        {
            return _capacity;
        }
    }
}