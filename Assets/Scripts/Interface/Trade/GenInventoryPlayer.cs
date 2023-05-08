using System.Collections.Generic;
using PlayerSystem;
using UnityEngine;
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
        for (int i = 0; i < inventory.Count; ++i)
        {
            Product product = inventory[i];
            GameObject productObject = ImageData.CreateProductObject(
                product.GetVisibleType(player.Wisdom), transform.GetChild(i), 200 / 100);
            productObject.transform.parent.gameObject.AddComponent<InventoryDrag>();
        }
    }
}
