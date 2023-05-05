using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerSystem
{
    public static class ImageData
    {
        private static readonly GameObject _inventoryCell;
        private static readonly Dictionary<string, Sprite> _productSprites;

        static ImageData()
        {
            _inventoryCell = Resources.Load("Prefabs/cell") as GameObject;

            _productSprites =
                (Resources.LoadAll("Images/Products") as Sprite[])
                .ToDictionary(sprite => sprite.name, sprite => sprite);
        }

        public static GameObject GetCellObject()
        {
            return _inventoryCell;
        }

        // create GameObject for Product in inventory
        // attach script for Drag & Drop
        public static GameObject GetProductObject(string type)
        {
            GameObject obj = new();
            GameObject productObj = new();
            productObj.transform.SetParent(obj.transform);
            Image img = obj.AddComponent<Image>();
            img.sprite = _productSprites[type];
            return obj;
        }
    }
}