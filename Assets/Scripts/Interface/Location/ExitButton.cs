using PlayerSystem;
using UnityEngine.SceneManagement;

public class ExitButton : ButtonTemplate
{
    public void OnMouseDown()
    {
        // GameData.Save();
        SceneManager.LoadScene(0);
    }
}
