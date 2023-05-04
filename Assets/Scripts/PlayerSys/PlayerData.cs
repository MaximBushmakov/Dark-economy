using System.Collections.Generic;

namespace PlayerSystem
{
    public class Player
    {
        private readonly WorldSystem.Inventory _inventory;
        private readonly Wagon _wagon;
        private int _money;
        private int _wisdom;

        public List<WorldSystem.Product> GetInventory()
        {
            return _inventory.getInventory();
        }

        public Wagon GetWagon()
        {
            return _wagon;
        }

        public int GetMoney()
        {
            return _money;
        }

        public int GetWisdom()
        {
            return _wisdom;
        }

        public Player()
        {
            _inventory = new WorldSystem.Inventory();
            _wagon = new Wagon("donkey", 10);
            _money = 100;
            _wisdom = 100;
        }
    }
}