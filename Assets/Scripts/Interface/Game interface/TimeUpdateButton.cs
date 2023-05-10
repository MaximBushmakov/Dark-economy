using PlayerSystem;
using UnityEngine.SceneManagement;

public class TimeUpdateButton : ButtonTemplate
{
    public void OnMouseDown()
    {
        GameData.UpdateTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
