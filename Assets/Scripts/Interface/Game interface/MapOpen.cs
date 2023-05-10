using UnityEngine.SceneManagement;

public class MapOpen : ButtonTemplate
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Карта");
    }
}
