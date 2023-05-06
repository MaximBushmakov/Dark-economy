using PlayerSystem;
using UnityEngine.SceneManagement;

public class HouseEnter : ButtonTemplate
{
    public void OnMouseDown()
    {
        GameData.Player.Sublocation = name;
        SceneManager.LoadScene(name);
    }
}
