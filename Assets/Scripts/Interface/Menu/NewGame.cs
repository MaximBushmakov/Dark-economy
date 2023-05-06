using System.Collections;
using System.Collections.Generic;
using PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : ButtonTemplate
{
    public void OnMouseDown()
    {
        GameData.NewGame();
        SceneManager.LoadScene(GameData.Player.Location);
    }
}
