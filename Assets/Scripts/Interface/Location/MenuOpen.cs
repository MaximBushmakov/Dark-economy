using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpen : ButtonTemplate
{
    [SerializeField] private GameObject _menuButtons;

    public new void Start()
    {
        base.Start();
        _menuButtons.SetActive(false);
    }

    public void OnMouseDown()
    {
        _menuButtons.SetActive(!_menuButtons.activeSelf);
    }
}
