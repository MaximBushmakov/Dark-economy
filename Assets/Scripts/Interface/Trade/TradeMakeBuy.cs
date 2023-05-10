using System;
using System.Linq;
using PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TradeMakeBuy : ButtonTemplate
{
    [SerializeField] private Transform _answer;
    private int _patience = 3;
    public void OnMouseDown()
    {
        int sum = 0;
        Transform content = SceneManager.GetActiveScene().GetRootGameObjects().ToList()
                 .Find(obj => obj.name == "Canvas").transform
                 .GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetChild(0);
        for (int i = 0; i < content.childCount; ++i)
        {
            if (content.GetChild(i).childCount == 1)
            {
                sum += content.GetChild(i).GetChild(0).GetComponent<PopUpTrade>().Price.GetTruePrice();
            }
        }

        int ans = Convert.ToInt32(transform.parent.GetChild(1).GetChild(0).GetComponent<InputField>().text);
        if (ans > GameData.Player.Money || (1 - (float)ans / sum) * 100 > GameData.Player.Charisma)
        {
            --_patience;
            if (_patience > 0)
            {
                _answer.GetChild(0).GetComponent<Text>().text = "Торговец не согласен";
            }
            else
            {
                GameData.CurPrices.SetBan(4);
                GameData.CurTrader.EndSellTrade(GameData.CurPrices);

                GameData.UpdateTime();

                transform.parent.gameObject.SetActive(false);
                transform.parent.parent.GetChild(2).gameObject.SetActive(true);
                return;
            }
        }
        else
        {
            _answer.GetChild(0).GetComponent<Text>().text = "Торговец согласен";
        }
        transform.parent.gameObject.SetActive(false);
        _answer.gameObject.SetActive(true);

    }
}
