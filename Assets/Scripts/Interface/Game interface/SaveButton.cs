using System.Collections;
using System.Collections.Generic;
using PlayerSystem;
using UnityEngine;

public class SaveButton : ButtonTemplate
{
    [SerializeField] private GameObject OkMessage;
    public void OnMouseDown()
    {
        GameData.Save();
        OkMessage.SetActive(true);
    }
}
