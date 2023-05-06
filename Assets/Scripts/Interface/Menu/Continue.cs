using PlayerSystem;
using UnityEngine.SceneManagement;

public class Continue : ButtonTemplate
{
    public void OnMouseDown()
    {
        GameData.Load();
        SceneManager.LoadScene(GameData.Player.Location);
    }
}
