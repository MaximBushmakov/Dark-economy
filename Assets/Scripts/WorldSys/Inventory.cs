using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using static WorldSystem.GlobalNames;

namespace WorldSystem
{
    [Serializable]
    public class Inventory
    {
        private List<Product> listOfProducts;

        [field: NonSerialized]
        private Random rand = new Random();

        [OnDeserialized]
        private void OnDeserializeMethod(StreamingContext context)
        {
            rand = new Random();
        }
        public Inventory()
        {
            listOfProducts = new List<Product>();
        }
        public void AddProduct(Product newProduct)
        {
            listOfProducts.Add(newProduct);
        }
        public List<Product> GetInventory()
        {
            return listOfProducts;
        }
        public int FindMinQ(string type, int wisdom)
        {
            int minQProductPlace = -1;
            int minQProductQuality = 5;
            for (int i = 0; i < listOfProducts.Count; ++i)
            {
                if (listOfProducts[i].GetVisibleType(wisdom) == type)
                {
                    if (listOfProducts[i].GetQuality() < minQProductQuality)
                    {
                        minQProductPlace = i;
                        minQProductQuality = listOfProducts[i].GetQuality();
                    }
                }
            }
            return minQProductPlace;
        }
        public void DeleteProd(int i)
        {
            listOfProducts[i].DeleteThis();
            listOfProducts.RemoveAt(i);
        }
        public void DeleteFromInventoryProd(int i)
        {
            listOfProducts.RemoveAt(i);
        }
        public bool EatFood(int wisdom)
        {
            for (int i = 0; i < listOfProducts.Count; ++i)
            {
                if (foodNames.Contains(listOfProducts[i].GetVisibleType(wisdom)))
                {
                    listOfProducts.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public void DeleteSomeProduct(int numb)
        {
            int randId;
            for (int i = 0; i < numb; ++i)
            {
                if (listOfProducts.Count > 0)
                {
                    randId = rand.Next() % listOfProducts.Count;
                    listOfProducts[randId].DeleteThis();
                    TimeSystem.GetInstance().WriteLog(listOfProducts[randId].GetSubType() + " был удалён");
                    listOfProducts.RemoveAt(randId);
                }
            }
        }
        public void AddProductType(string type, int numb)
        {
            switch (type)
            {
                case NormalMilletName:
                    for (int i = 0; i < numb; ++i)
                    {
                        listOfProducts.Add(new NormalMillet());
                    }
                    break;
                case BadMilletName:
                    for (int i = 0; i < numb; ++i)
                    {
                        listOfProducts.Add(new BadMillet());
                    }
                    break;
                case GoldenMilletName:
                    for (int i = 0; i < numb; ++i)
                    {
                        listOfProducts.Add(new GoldenMillet());
                    }
                    break;
                case NormalFlourName:
                    for (int i = 0; i < numb; ++i)
                    {
                        listOfProducts.Add(new NormalFlour());
                    }
                    break;
                case BadFlourName:
                    for (int i = 0; i < numb; ++i)
                    {
                        listOfProducts.Add(new BadFlour());
                    }
                    break;
                case GoldenFlourName:
                    for (int i = 0; i < numb; ++i)
                    {
                        listOfProducts.Add(new GoldenFlour());
                    }
                    break;
                case NormalBreadName:
                    for (int i = 0; i < numb; ++i)
                    {
                        listOfProducts.Add(new NormalBread());
                    }
                    break;
                case BadBreadName:
                    for (int i = 0; i < numb; ++i)
                    {
                        listOfProducts.Add(new BadBread());
                    }
                    break;
                case GoldenBreadName:
                    for (int i = 0; i < numb; ++i)
                    {
                        listOfProducts.Add(new GoldenBread());
                    }
                    break;
            }

        }
    }
}