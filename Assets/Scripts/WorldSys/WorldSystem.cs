using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    public class WorldSystem{
        private static TimeSystem timeSystem;
        private static void printPricesSell(NPC thisNPC){
            Prices thisPrices = thisNPC.makePricesSell();
            List<Price> listOfPrices = thisPrices.getPrices();
            for(int i = 0; i < listOfPrices.Count; ++i){
                Console.WriteLine("Цена на " + listOfPrices[i].getProduct().getSubType() + " воспринимаемое как " + listOfPrices[i].getProduct().getType(thisNPC.getWisdomLevel()) + " имеет реальную цену " + listOfPrices[i].getTruePrice() + " а так же выставляемую цену " + listOfPrices[i].getViewPrice());
            }
        }
        static void Main(string[] args){
            timeSystem = TimeSystem.getInstance();
            Location newlocation = new Location("Деревня", VillageName);
            newlocation = new Location("Город", TownName);
            NPC newNPC = new Fermer("Марк", "Деревня", 0, 0);
            newNPC = new Millworker("Рудольф", "Деревня", 0, 0);
            newNPC = new Fermer("Олег", "Деревня", 0, 0);
            newNPC = new Baker("Андрей", "Город", 0, 0);
            newNPC = new Trader("Джон", new List<string>() { "Деревня", "Город" }, new List<List<string>>() { new List<string>() { ElderProfessionName, FermerProfessionName , MillworkerProfessionName }, new List<string>() { BakerProfessionName }}, 0, 0);
            newNPC = new Elder("Александро", "Деревня", 0, 0);
            newNPC.addEffect(new PriceEffect("Рождение ребёнка", 2, 100, "All"));
            timeSystem.startFirstEvent();
            for(int i = 0; i < 15; ++i){
                TimeSystem.getInstance().writeLog("Идёт тик " + i.ToString());
                Console.WriteLine("Идёт тик " + i.ToString());
                timeSystem.makeTicks(1);
            }
            TimeSystem.getInstance().endLog();
        }
    }
}