using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    public class WorldSystem{
        private static TimeSystem timeSystem;
        private static void printPricesSell(NPC thisNPC){
            Prices thisPrices = thisNPC.MakePricesSell();
            List<Price> listOfPrices = thisPrices.GetPrices();
            for(int i = 0; i < listOfPrices.Count; ++i){
                Console.WriteLine("Цена на " + listOfPrices[i].GetProduct().GetSubType() + " воспринимаемое как " + listOfPrices[i].GetProduct().GetVisibleType(thisNPC.GetWisdomLevel()) + " имеет реальную цену " + listOfPrices[i].GetTruePrice() + " а так же выставляемую цену " + listOfPrices[i].GetViewPrice());
            }
        }
        static void Main(string[] args){
            timeSystem = TimeSystem.GetInstance();
            Location newlocation = new Location("Деревня", VillageName);
            newlocation = new Location("Город", TownName);
            NPC newNPC = new Fermer("Марк", "Деревня");
            newNPC = new Millworker("Рудольф", "Деревня");
            newNPC = new Fermer("Олег", "Деревня");
            newNPC = new Baker("Андрей", "Город");
            newNPC = new Trader("Джон", new List<string>() { "Деревня", "Город" }, new List<List<string>>() { new List<string>() { ElderProfessionName, FermerProfessionName , MillworkerProfessionName }, new List<string>() { BakerProfessionName }});
            newNPC = new Elder("Александро", "Деревня");
            newNPC.AddEffect(new PriceEffect("Рождение ребёнка", 2, 100, "All"));
            timeSystem.StartFirstEvent();
            for(int i = 0; i < 15; ++i){
                TimeSystem.GetInstance().WriteLog("Идёт тик " + i.ToString());
                Console.WriteLine("Идёт тик " + i.ToString());
                timeSystem.MakeTicks(1);
            }
            TimeSystem.GetInstance().EndLog();
        }
    }
}