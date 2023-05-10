using System;
using PlayerSystem;
using UnityEngine;
using UnityEngine.UI;

public class TalkAction : ButtonTemplate
{
    [SerializeField] private Transform _message;
    public void OnMouseDown()
    {
        if (GameData.CurTrader.CheckBan() == true)
        {
            _message.GetChild(0).GetComponent<Text>().text = GameData.CurTrader.GetRumor();
            _message.gameObject.SetActive(true);
        }
    }
}