using UnityEngine.SceneManagement;

public class BuyAction : ButtonTemplate
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Buy");
    }
}
