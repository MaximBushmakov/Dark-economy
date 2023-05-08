using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PlayerSystem
{
    public static class ImageData
    {
        private static readonly GameObject _inventoryCell;
        private static readonly Dictionary<string, Sprite> _productSprites;
        private static readonly Dictionary<string, Sprite> _npcSprites;

        static ImageData()
        {
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

        // create GameObject for Product in inventory
        public static GameObject CreateProductObject(string type, Transform parent, float size)
        {
            GameObject obj = Object.Instantiate(_inventoryCell, parent);
            GameObject productObj = new();
            productObj.transform.SetParent(obj.transform);
            Image img = productObj.AddComponent<Image>();
            img.sprite = _productSprites[type];
            RectTransform transform = obj.GetComponent<RectTransform>();
            transform.anchorMin = new Vector2(0.5f, 0.5f);
            transform.anchorMax = new Vector2(0.5f, 0.5f);
            transform.pivot = new Vector2(0.5f, 0.5f);
            productObj.GetComponent<RectTransform>().anchoredPosition = new(0, 0);
            productObj.transform.localScale = new(0.8f * size, 0.8f * size);
            return obj;
        }

        public static GameObject CreateNPCObject(string name, Transform parent)
        {
            GameObject obj = new(name);
            obj.AddComponent<Image>().sprite = _npcSprites[name];
            obj.transform.SetParent(p: parent);
            RectTransform rectTransform = obj.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.anchoredPosition = new(0, 0);
            rectTransform.sizeDelta = new(2, 3);
            var collider = obj.AddComponent<BoxCollider2D>();
            collider.isTrigger = true;
            collider.size = new(2, 3);
            GameObject actions = SceneManager.GetActiveScene().GetRootGameObjects().ToList()
                .Find(obj => obj.name == "Canvas")
                .GetComponentsInChildren<Transform>(true).ToList()
                .Find(transform => transform.name == "Action buttons").gameObject;
            obj.AddComponent<NPCDialogOpen>().SetActionButtons(actions);
            return obj;
        }
    }
}