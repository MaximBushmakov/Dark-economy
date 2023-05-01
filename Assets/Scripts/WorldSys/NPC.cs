using System;
using System.Collections.Generic;

namespace WorldSystem
{
    class NPC
    {
        protected string name;
        protected string location;
        protected float xCord;
        protected float yCord;
        protected Inventory inventory;
        protected Random rand;
        protected int wisdomLevel;
        protected int kapital;
        protected int playerReputation;
        private List<Effect> ListOfEffects;
        public NPC(string npcName, string npcLocation, float npcXCord, float npcYCord, int wisdomlevel, int money, int reputation)
        {
            name = npcName;
            location = npcLocation;
            xCord = npcXCord;
            yCord = npcYCord;
            wisdomlevel = wisdomLevel;
            rand = new Random();
            inventory = new Inventory();
            kapital = money;
            playerReputation = reputation;
            ListOfEffects = new List<Effect>();
            TimeSystem.getInstance().addNPCtoTimeSystem(this);
        }
        public string getName()
        {
            return name;
        }
        public void proveInventory()
        {
            List<Product> products = inventory.getInventory();
            for (int i = products.Count - 1; i >= 0; --i)
            {
                if (products[i].getQuality() == 0)
                {
                    Console.WriteLine(name + " выкидывает " + products[i].getSubType());
                    products.RemoveAt(i);
                }
            }
        }
        public void proveEffects()
        {
            for (int i = ListOfEffects.Count - 1; i >= 0; --i)
            {
                if (ListOfEffects[i].provDone())
                {
                    Console.WriteLine(ListOfEffects[i].getName() + " перестаёт оказывать эффект на " + name);
                    ListOfEffects.RemoveAt(i);
                }
            }
        }
        public virtual void produceProduct()
        {
            int randNum;
            randNum = rand.Next() % 100;
            switch (randNum)
            {
                case > 90:
                    break;
                case > 50:
                    break;
                default:
                    break;
            }
        }
        public void makeTick()
        {
            proveInventory();
            proveEffects();
            produceProduct();
        }
        public string getLocation()
        {
            return location;
        }
        public void addEffect(Effect thisEffect)
        {
            ListOfEffects.Add(thisEffect);
        }
    }
}