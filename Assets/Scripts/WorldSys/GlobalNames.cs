using System;
using static WorldSystem.GlobalNames;
using System.Collections.Generic;

namespace WorldSystem
{
    public static class GlobalNames{
        public const string VillageName = "Деревня";
        public const string TownName = "Город";
        public const string RoadName = "Дорога";
        public const string GoodRoadEventName = "Хорошее событие в пути";
        public const string BadRoadEventName = "Плохое событие в пути";
        public const string GoodTownEventName = "Хорошее событие в городе";
        public const string BadTownEventName =  "Плохое событие в городе";
        public const string GoodVillageEventName = "Хорошее событие в деревне";
        public const string BadVillageEventName = "Плохое событие в деревне";
        public const string KapitalLocalEffectName = "Капитал";
        public const string ReputationLocalEffectName = "Репутация";
        public const string ElderProfessionName = "Старейшина";
        public const string FermerProfessionName = "Фермер";
        public const string MillworkerProfessionName = "Мельник";
        public const string TraderProfessionName = "Торговец";
        public const string BakerProfessionName = "Пекарь";
        public const string AllProductsName = "Все товары";
        public const string AllLocationsName = "Все локации";
        public const string NormalMilletName = "Пшено";
        public const string GoldenMilletName = "Золотое Пшено";
        public const string BadMilletName = "Пшено для скота";
        public const string NormalFlourName = "Мука";
        public const string GoldenFlourName = "Золотая Мука";
        public const string BadFlourName = "Твёрдая мука";
        public const string NormalBreadName = "Хлеб";
        public const string GoldenBreadName = "Королевский Хлеб";
        public const string BadBreadName = "Чёрствый Хлеб";
        public const string PriceEffectType = "Цена";
        public static readonly string[] foodNames = {NormalBreadName, BadBreadName, GoldenBreadName};
        public static readonly string[] sellerNames = {ElderProfessionName, BakerProfessionName};
    }
}
