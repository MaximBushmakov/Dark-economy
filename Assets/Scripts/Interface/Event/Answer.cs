using System.Collections;
using System.Collections.Generic;
using PlayerSystem;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    private Text _text;
    public void Start()
    {
        _text = GetComponent<Text>();
        var collider = gameObject.AddComponent<BoxCollider2D>();
        collider.size = new(300, 100);
        collider.isTrigger = true;
    }

    public void OnMouseEnter()
    {
        _text.fontStyle = FontStyle.Bold;
    }

    public void OnMouseExit()
    {
        _text.fontStyle = FontStyle.Normal;
    }

    public void OnMouseDown()
    {
        _text.fontStyle = FontStyle.Normal;
        GameData.HandleEvent(transform.name[^1] - '0');
    }
}
