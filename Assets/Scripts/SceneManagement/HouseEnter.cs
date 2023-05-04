using PlayerSystem;
using UnityEngine.SceneManagement;

public class HouseEnter : ButtonTemplate
{
    public void OnMouseDown()
    {
        GameData.SetLocationName(name);
        SceneManager.LoadScene(name);
    }
}
