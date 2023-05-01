using System.Collections;
using System.Collections.Generic;
using PlayerSystem;
using UnityEngine;

public class GenInventoryPlayer : MonoBehaviour
{
    [SerializeField] private GameObject cell;
    public void Start()
    {
        int size = GameData.GetPlayer().GetWagon().GetCapacity();
        GetComponent<RectTransform>().sizeDelta = new Vector2(0, (size / 3 + 1) * 200);
        for (int i = 0; i < size; ++i)
        {
            Instantiate(cell, transform);
        }
    }
}
