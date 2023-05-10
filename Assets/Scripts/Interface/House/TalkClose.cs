using PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkClose : MonoBehaviour
{
    public void OnMouseDown()
    {
        GameData.UpdateTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
