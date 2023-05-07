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
        SceneManager.LoadScene(GameData.Player.Location);
    }
}
