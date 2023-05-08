using System.Collections;
using System.Collections.Generic;
using PlayerSystem;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerMoney : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Text>().text = GameData.Player.Money.ToString();
    }
}
