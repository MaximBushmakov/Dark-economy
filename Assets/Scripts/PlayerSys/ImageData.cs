using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
using WorldSystem;

namespace PlayerSystem
{
    public static class ImageData
    {
        private static readonly Font _font;
        private static readonly GameObject _inventoryCell;
        private static readonly Dictionary<string, Sprite> _productSprites;
        private static readonly Dictionary<string, Sprite> _npcSprites;

        static ImageData()
        {
            _font = Resources.Load("Halogen_0") as Font;
            _inventoryCell = Resources.Load("Prefabs/cell") as GameObject;
            _productSprites =
                Resources.LoadAll("Images/Products", typeof(Sprite)).Cast<Sprite>()
                .ToDictionary(sprite => sprite.name, sprite => sprite);
            _npcSprites =
                Resources.LoadAll("Images/NPC", typeof(Sprite)).Cast<Sprite>()
                .ToDictionary(sprite => sprite.name, sprite => sprite);
        }

        public static GameObject GetCellObject()
        {
            return _inventoryCell;
        }

        public static GameObject CreateProductObject(Product product, Transform parent, float size, GameObject dataObject)
        {
            string productName = product.GetVisibleType(GameData.Player.Wisdom);
            GameObject obj = Object.Instantiate(_inventoryCell, parent);
            obj.name = productName;
            GameObject productObj = new();
            productObj.transform.SetParent(obj.transform);
            Image img = productObj.AddComponent<Image>();
            img.sprite = _productSprites[productName];
            RectTransform rectTransform = obj.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.localScale = new(1, 1);
            rectTransform.sizeDelta = new Vector2(size, size);

            RectTransform productRectTransform = productObj.GetComponent<RectTransform>();
            productRectTransform.anchoredPosition = new(0, 0);
            productRectTransform.localScale = new Vector2(0.8f, 0.8f);
            productRectTransform.sizeDelta = new Vector2(size, size);
            var collider = obj.AddComponent<BoxCollider2D>();
            collider.size = new(size, size);
            var popup = obj.AddComponent<PopUp>();
            popup.SetDataObject(dataObject);
            popup.SetProduct(product);
            return obj;
        }

        public static GameObject CreateTradeProductObject(Price price, Transform parent, float size, GameObject dataObject)
        {
            string productName = price.GetProduct().GetVisibleType(GameData.Player.Wisdom);
            GameObject obj = Object.Instantiate(_inventoryCell, parent);
            obj.name = productName;
            GameObject productObj = new();
            productObj.transform.SetParent(obj.transform);
            Image img = productObj.AddComponent<Image>();
            img.sprite = _productSprites[productName];
            RectTransform rectTransform = obj.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.localScale = new(1, 1);
            rectTransform.sizeDelta = new Vector2(size, size);

            RectTransform productRectTransform = productObj.GetComponent<RectTransform>();
            productRectTransform.anchoredPosition = new(0, 0);
            productRectTransform.localScale = new Vector2(0.8f, 0.8f);
            productRectTransform.sizeDelta = new Vector2(size, size);
            var collider = obj.AddComponent<BoxCollider2D>();
            collider.size = new(size, size);
            var popup = obj.AddComponent<PopUpTrade>();
            popup.SetDataObject(dataObject);
            popup.Price = price;
            return obj;
        }

        public static GameObject CreateNPCObject(string name, Transform parent, GameObject actions, float size)
        {
            GameObject obj = new(name);
            obj.AddComponent<SpriteRenderer>().sprite = _npcSprites[name];
            obj.transform.SetParent(p: parent);

            RectTransform rectTransform = obj.AddComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.anchoredPosition = new(0, 0);
            rectTransform.sizeDelta = new(1, 1);
            rectTransform.localScale = new(size, size);

            var collider = obj.AddComponent<BoxCollider2D>();
            collider.isTrigger = true;
            collider.size = new(2, 3);
            obj.AddComponent<NPCDialogOpen>().SetActionButtons(actions);

            GameObject nameplateObj = new();
            nameplateObj.transform.SetParent(obj.transform);
            var cell = nameplateObj.AddComponent<SpriteRenderer>();
            cell.sprite = _inventoryCell.GetComponent<Image>().sprite;
            rectTransform = nameplateObj.AddComponent<RectTransform>();
            rectTransform.sizeDelta = new(1, 1);
            rectTransform.localScale = new(0.7f, 0.7f);
            rectTransform.anchoredPosition = new(0, -4.5f);

            GameObject text = new();
            text.transform.SetParent(nameplateObj.transform);
            Text _text = text.AddComponent<Text>();
            _text.text = name;
            _text.font = _font;
            _text.fontSize = 80;
            _text.alignment = TextAnchor.MiddleCenter;
            _text.color = Color.black;

            rectTransform = text.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new(0, 0);
            rectTransform.sizeDelta = new(400, 80);
            rectTransform.localScale = new(0.02f, 0.02f);

            return obj;
        }
    }
}