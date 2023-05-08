using PlayerSystem;
using UnityEngine;

public class GenInventoryTrader : MonoBehaviour
{
    public void Start()
    {
        Player player = GameData.Player;
        int size = player.Capacity;
        // grid has 3 cells in a row, cells has size 200 x 200
        GetComponent<RectTransform>().sizeDelta = new Vector2(0, (size / 3 + 1) * 200);
        var cell = ImageData.GetCellObject();
        for (int i = 0; i < size; ++i)
        {
            Instantiate(cell, transform);
        }
    }
}
