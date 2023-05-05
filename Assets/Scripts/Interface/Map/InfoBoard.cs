using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBoard : MonoBehaviour
{
    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetText(string text)
    {
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = text;
    }

}
