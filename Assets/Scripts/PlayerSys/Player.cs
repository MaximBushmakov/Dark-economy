using System;
using System.Collections.Generic;
using System.Reflection;
using WorldSystem;

namespace PlayerSystem
{
    [Serializable]
    public class Player
    {
        private readonly Inventory _inventory;
        public List<Product> Inventory { get => _inventory.GetInventory(); }
        public Inventory GetInventory()
        {
            return _inventory;
        }
        public void AddProduct(Product product)
        {
            _inventory.AddProduct(product);
        }

        public void RemoveProduct(int i)
        {
            _inventory.DeleteProd(i);
        }
        private readonly Wagon _wagon;
        public int Capacity { get => _wagon.Capacity; }
        public float Speed { get => _wagon.Speed; }
        public string WagonName { get => _wagon.Name; }
        private int _money;
        public int Money { get => _money; set => _money = value; }
        private int _reputation;
        public int Reputation { get => _reputation; }
        private int _wisdom;
        public int Wisdom { get => _wisdom / 2; }
        private int _charisma;
        public int Charisma { get => _charisma / 2; }

        public void UpdateStats()
        {
            ++_wisdom;
            ++_charisma;
        }


        private string _location;
        public string Location
        {
            get => _location;
            set
            {
                if (!LocationData.Locations.ContainsKey(value))
                {
                    throw new Exception("There is no location named " + value);
                }
                _location = value;
            }
        }

        private string _sublocation;
        public string Sublocation
        {
            get => _sublocation;
            set
            {
                if (!LocationData.Locations[_location].GetSublocations().Contains(value))
                {
                    throw new Exception("There is no sublocation named " + value + " in location named " + _location);
                }
                _sublocation = value;

            }
        }

        public Player()
        {
            _inventory = new Inventory();
            _inventory.AddProduct(new BadMillet());
            _inventory.AddProduct(new NormalMillet());
            _inventory.AddProduct(new GoldenMillet());
            _inventory.AddProduct(new GoldenMillet());
            _wagon = WagonData.Donkey;
            _money = 1000;
            _wisdom = 40;
            _charisma = 0;
            _location = "Деревня";
            _sublocation = "Деревня";
        }
    }
}