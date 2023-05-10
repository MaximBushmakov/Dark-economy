using System.Collections.Generic;
using System.Linq;
using PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using WorldSystem;

public class GenInventoryTraderBuy : MonoBehaviour
{
    public void Start()
    {
        Player player = GameData.Player;
        NPC trader = GameData.CurTrader;
        GameData.CurPrices = trader.MakePricesSell();
        List<Price> inventory = GameData.CurPrices.GetPrices();
        int size = inventory.Count;
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
            GameObject productObject = ImageData.CreateTradeProductObject(
                inventory[i], transform.GetChild(i), 200, dataObject);
            productObject.gameObject.AddComponent<InventoryDrag>();
        }
    }
}
