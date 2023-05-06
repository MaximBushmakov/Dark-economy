using System.Collections;
using System.Collections.Generic;
using PlayerSystem;
using UnityEngine;

public class NewGame : ButtonTemplate
{
    public void OnMouseDown()
    {
        Debug.Log("Start");
        GameData.NewGame();
        GameData.Save();
        GameData.Load();
    }
}
