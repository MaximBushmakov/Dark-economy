using System.Collections.Generic;
using System.Linq;
using PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using WorldSystem;

public class GenInventoryPlayerBuy : MonoBehaviour
{
    public void Start()
    {
        int size = GameData.Player.Capacity;
        // grid has 3 cells in a row, cells has size 200 x 200
        GetComponent<RectTransform>().sizeDelta = new Vector2(0, (size / 3 + 1) * 200);
        var cell = ImageData.GetCellObject();
        for (int i = 0; i < size - GameData.Player.Inventory.Count; ++i)
        {
            GameObject curCell = Instantiate(cell, transform);
            var collider = curCell.AddComponent<BoxCollider2D>();
            collider.isTrigger = true;
            collider.size = new(200, 200);
        }
    }
}
