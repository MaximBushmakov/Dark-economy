using System.Collections;
using System.Collections.Generic;
using PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToMainButton : ButtonTemplate
{
    public void OnMouseDown()
    {
        GameData.Player.Sublocation = GameData.Player.Location;
        SceneManager.LoadScene(GameData.Player.Location);
    }
}
