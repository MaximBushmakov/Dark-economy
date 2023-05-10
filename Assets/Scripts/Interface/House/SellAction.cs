using UnityEngine.SceneManagement;

public class SellAction : ButtonTemplate
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Продажа");
    }
}
