using System.Collections.Generic;
using WorldSystem;

namespace PlayerSystem
{
    public class Player
    {
        private readonly Inventory _inventory;
        private readonly Wagon _wagon;
        private int _money;
        private int _wisdom;
        private int _reputation;

        public List<Product> GetInventory()
        {
            return _inventory.GetInventory();
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

        public int GetReputation()
        {
            return _reputation;
        }

        public Player()
        {
            _inventory = new Inventory();
            _inventory.AddProduct(new BadMillet());
            _inventory.AddProduct(new NormalMillet());
            _inventory.AddProduct(new GoldenMillet());
            _wagon = WagonData.Donkey;
            _money = 100;
            _wisdom = 0;
        }
    }
}