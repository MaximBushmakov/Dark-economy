using PlayerSystem;
using UnityEngine.SceneManagement;

public class HouseEnter : ButtonTemplate
{
    public void OnMouseDown()
    {
        GameData.Player.Location = name;
        SceneManager.LoadScene(name);
    }
}
