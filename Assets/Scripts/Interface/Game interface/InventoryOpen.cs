using UnityEngine.SceneManagement;

public class InventoryOpen : ButtonTemplate
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Инвентарь");
    }
}
