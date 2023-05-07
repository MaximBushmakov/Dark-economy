using PlayerSystem;
using UnityEngine.SceneManagement;

public class LoadButton : ButtonTemplate
{
    public void OnMouseDown()
    {
        GameData.Load();
        SceneManager.LoadScene(GameData.Player.Location);
    }
}
