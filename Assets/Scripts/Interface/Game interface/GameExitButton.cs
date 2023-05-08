using PlayerSystem;
using UnityEngine.SceneManagement;

public class GameExitButton : ButtonTemplate
{
    public void OnMouseDown()
    {
        // GameData.Save();
        SceneManager.LoadScene(0);
    }
}
