using System.Collections.Generic;
using System.IO;

namespace WorldSystem
{
    public class ProductData
    {
        public string Type { get; set; }
        public string SubType { get; set; }
        public int BasicCost { get; set; }
        public int MainCost { get; set; }
        public int WisdomLevel { get; set; }
        public int[] TickLimits { get; set; }
    }
}