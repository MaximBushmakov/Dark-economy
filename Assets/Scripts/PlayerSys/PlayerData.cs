using System.ComponentModel;

namespace PlayerSystem
{
    public class Player
    {
        private readonly WorldSystem.Inventory _inventory;
        private readonly Wagon _wagon;
        private int _money;

        public WorldSystem.Inventory GetInventory()
        {
            return _inventory;
        }

        public Wagon GetWagon()
        {
            return _wagon;
        }

        public int GetMoney()
        {
            return _money;
        }

        public Player()
        {
            _inventory = new WorldSystem.Inventory();
            _wagon = new Wagon("donkey", 10);
            _money = 100;
        }
    }
}