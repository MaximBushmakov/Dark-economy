using System.Collections;
using System.Collections.Generic;
using PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using WorldSystem;

public class NewGame : ButtonTemplate
{
    public void OnMouseDown()
    {
        TimeSystem.GetInstance();
        GameData.NewGame();
        SceneManager.LoadScene(GameData.Player.Location);
    }
}
