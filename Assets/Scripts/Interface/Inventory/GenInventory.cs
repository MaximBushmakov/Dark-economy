using System.Collections.Generic;
using System.Linq;
using PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using WorldSystem;

public class GenInventory : MonoBehaviour
{
    public void Start()
    {
        Player player = GameData.Player;
        int size = player.Capacity;
        List<Product> inventory = player.Inventory;
        // grid has 3 cells in a row, cells has size 200 x 200
        GetComponent<RectTransform>().sizeDelta = new Vector2(0, (size / 3 + 1) * 200);

        GameObject dataObject = SceneManager.GetActiveScene().GetRootGameObjects().ToList()
                .Find(obj => obj.name == "Canvas")
                .GetComponentsInChildren<RectTransform>(true).ToList()
                .Find(transform => transform.name == "Data message").gameObject;

        for (int i = 0; i < inventory.Count; ++i)
        {
            Product product = inventory[i];
            ImageData.CreateProductObject(product, transform, 100, dataObject);
        }

        var cell = ImageData.GetCellObject();
        for (int i = inventory.Count; i < size; ++i)
        {
            Instantiate(cell, transform);
        }
    }
}
