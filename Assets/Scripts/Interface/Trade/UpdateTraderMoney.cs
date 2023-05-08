using System.Collections;
using System.Collections.Generic;
using PlayerSystem;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTraderMoney : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Text>().text = GameData.CurTrader.GetKapital().ToString();
    }
}
