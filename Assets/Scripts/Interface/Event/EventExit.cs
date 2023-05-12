using PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventExit : MonoBehaviour
{
    private Text _text;
    public void Start()
    {
        _text = GetComponent<Text>();
        var collider = gameObject.AddComponent<BoxCollider2D>();
        collider.size = new(100, 100);
        collider.isTrigger = true;
    }

    public void OnMouseEnter()
    {
        _text.fontStyle = FontStyle.Bold;
    }

    public void OnMouseExit()
    {
        _text.fontStyle = FontStyle.Normal;
    }

    public void OnMouseDown()
    {
        transform.parent.gameObject.SetActive(false);

        if (GameData.CurEvents.Count == 0)
        {
            GameData.CurEvent = null;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        GameData.UpdateEvent();

    }
}
