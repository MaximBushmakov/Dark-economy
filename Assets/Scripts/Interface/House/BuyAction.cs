using PlayerSystem;
using UnityEngine.SceneManagement;

public class BuyAction : ButtonTemplate
{
    public void OnMouseDown()
    {
        if (GameData.CurTrader.CheckBan() == true && GameData.Player.Reputation > 0)
        {
            SceneManager.LoadScene("Покупка");
        }
    }
}
