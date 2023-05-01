using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTemplate : MonoBehaviour
{
    private new Renderer renderer;
    protected void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    protected void OnMouseEnter()
    {
        renderer.material.color = new Color(0.9f, 0.9f, 0.9f, 1);
    }

    protected void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
