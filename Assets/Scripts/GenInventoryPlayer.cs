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
            GameObject curCell = Instantiate(cell, transform.GetChild(i));
            Product product = inventory[i];
            Instantiate(ImageData.GetProductObject(product.GetVisibleType(player.Wisdom)),
                curCell.transform);
        }
    }
}
