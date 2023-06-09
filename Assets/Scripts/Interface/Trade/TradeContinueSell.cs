using System;
using System.Linq;
using PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WorldSystem;

public class TradeContinueSell : ButtonTemplate
{
    public void OnMouseDown()
    {
        if (transform.parent.GetChild(0).GetComponent<Text>().text == "Торговец согласен")
        {
            Prices prices = GameData.CurPrices;
            var playerCells = SceneManager.GetActiveScene().GetRootGameObjects().ToList()
                .Find(obj => obj.name == "Canvas").transform
                .GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetChild(0);
            for (int i = 0; i < GameData.Player.Inventory.Count; ++i)
            {
                if (playerCells.GetChild(i).childCount == 0)
                {
                    prices.AddBought(i);
                    GameData.Player.RemoveProduct(i);
                }
            }

            int ans = Convert.ToInt32(transform.parent.parent
                .GetChild(0).GetChild(1).GetChild(0)
                .GetComponent<InputField>().text);

            prices.SetMoney(ans);
            GameData.Player.Money += ans;

            int sum = 0;
            Transform traderCells = SceneManager.GetActiveScene().GetRootGameObjects().ToList()
                     .Find(obj => obj.name == "Canvas").transform
                     .GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0);
            for (int i = 0; i < traderCells.childCount; ++i)
            {
                if (traderCells.GetChild(i).childCount == 1)
                {
                    Price price = traderCells.GetChild(i).GetChild(0).GetComponent<PopUpTrade>().Price;
                    sum += price.GetTruePrice();
                }
            }

            prices.SetReputationChange(sum / 100 + (sum - ans) / 10);

            GameData.CurTrader.EndBuyTrade(prices);

            GameData.Player.UpdateStats();

            transform.parent.gameObject.SetActive(false);
            transform.parent.parent.GetChild(3).gameObject.SetActive(true);
        }
        else
        {
            transform.parent.gameObject.SetActive(false);
            transform.parent.parent.GetChild(0).gameObject.SetActive(true);
        }

    }
}
