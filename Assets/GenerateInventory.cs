using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateInventory : MonoBehaviour
{
    public void Start()
    {
        for (int i = 0; i < 5; ++i)
        {
            Instantiate(transform.GetChild(0).gameObject, transform);
        }
    }
}
