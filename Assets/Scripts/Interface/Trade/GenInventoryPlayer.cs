using System.Collections.Generic;
using System.Linq;
using PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using WorldSystem;

public class GenInventoryPlayer : MonoBehaviour
{
    public void Start()
    {
        Player player = GameData.Player;
        int size = player.Capacity;
        List<Product> inventory = player.Inventory;
        // grid has 3 cells in a row, cells has size 200 x 200
        GetComponent<RectTransform>().sizeDelta = new Vector2(0, (size / 3 + 1) * 200);
        var cell = ImageData.GetCellObject();
        for (int i = 0; i < size; ++i)
        {
            Instantiate(cell, transform);
        }

        GameObject dataObject = SceneManager.GetActiveScene().GetRootGameObjects().ToList()
                .Find(obj => obj.name == "Canvas")
                .GetComponentsInChildren<RectTransform>(true).ToList()
                .Find(transform => transform.name == "Data message").gameObject;
        for (int i = 0; i < inventory.Count; ++i)
        {
            Product product = inventory[i];
            GameObject productObject = ImageData.CreateProductObject(
                product, transform.GetChild(i), 200 / 100, dataObject);
            productObject.transform.parent.gameObject.AddComponent<InventoryDrag>();
        }
    }
}
