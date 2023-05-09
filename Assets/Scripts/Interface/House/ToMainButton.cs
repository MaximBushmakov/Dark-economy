using PlayerSystem;
using UnityEngine.SceneManagement;

public class ToMainButton : ButtonTemplate
{
    public void OnMouseDown()
    {
        GameData.Player.Sublocation = GameData.Player.Location;
        SceneManager.LoadScene(GameData.Player.Location);
    }
}
