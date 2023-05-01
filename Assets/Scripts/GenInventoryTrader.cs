using System.Collections;
using System.Collections.Generic;
using PlayerSystem;
using UnityEngine;

public class GenInventoryTrader : MonoBehaviour
{
    [SerializeField] private GameObject cell;
    private const int size = 50;
    public void Start()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(0, (size / 3 + 1) * 200);
        for (int i = 0; i < size; ++i)
        {
            Instantiate(cell, transform);
        }
    }
}
