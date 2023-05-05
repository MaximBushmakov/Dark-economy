using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WorldSystem;

namespace PlayerSystem
{
    public class Player
    {
        private Inventory _inventory;
        public List<Product> Inventory { get => _inventory.GetInventory(); }
        private readonly Wagon _wagon;
        public int Capacity { get => _wagon.Capacity; }
        public float Speed { get => _wagon.Speed; }
        private int _money;
        public int Money { get => _money; }
        private int _reputation;
        public int Reputation { get => _reputation; }
        private int _wisdom;
        public int Wisdom { get => _wisdom; }


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
                if (!LocationData.Locations[_location].Sublocations.Contains(value))
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
            _wagon = WagonData.Donkey;
            _money = 100;
            _wisdom = 0;
        }
    }
}