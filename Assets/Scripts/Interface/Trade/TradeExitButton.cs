using PlayerSystem;
using UnityEngine.SceneManagement;

public class TradeExitButton : ButtonTemplate
{
    public void OnMouseDown()
    {
        GameData.UpdateTime();
    }
}
