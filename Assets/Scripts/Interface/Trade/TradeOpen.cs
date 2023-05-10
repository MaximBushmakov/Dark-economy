using System.Collections;
using System.Collections.Generic;
using PlayerSystem;
using UnityEngine;
using UnityEngine.UI;

public class TradeOpen : ButtonTemplate
{
    [SerializeField] private GameObject _tradeMessage;
    public void OnMouseDown()
    {
        int sum = 0;
        Transform content = transform.parent.GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetChild(0);
        for (int i = 0; i < content.childCount; ++i)
        {
            if (content.GetChild(i).childCount == 1)
            {
                sum += content.GetChild(i).GetChild(0).GetComponent<PopUpTrade>().Price.GetViewPrice();
            }
        }

        _tradeMessage.SetActive(true);
        _tradeMessage.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = sum.ToString();
    }
}
