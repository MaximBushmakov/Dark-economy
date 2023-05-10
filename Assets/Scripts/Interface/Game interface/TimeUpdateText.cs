using System.Collections;
using System.Collections.Generic;
using PlayerSystem;
using UnityEngine;
using UnityEngine.UI;

public class TimeUpdateText : MonoBehaviour
{
    public void Start()
    {
        transform.GetChild(0).GetComponent<Text>().text = "День " + GameData.Day + " " + GameData.TimeOfDay;
    }
}
