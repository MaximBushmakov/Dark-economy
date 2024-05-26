using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WorldSystem
{
    public class ProductFactory
    {
        public Product CreateProduct(string subtype)
        {
            var jsonData = File.ReadAllText("Assets/Scripts/WorldSys/products.json");
            var productList = JsonConvert.DeserializeObject<List<ProductData>>(jsonData);
            var productData = productList.FirstOrDefault(p => p.SubType == subtype);

            if (productData == null)
            {
                throw new ArgumentException($"Product subtype '{subtype}' not found in the JSON data.");
            }

            return new Product(productData.Type, productData.SubType, productData.BasicCost, productData.MainCost, productData.WisdomLevel, productData.TickLimits);
        }
    }
}