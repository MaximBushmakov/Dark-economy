using PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TradeExitButton : MonoBehaviour
{
    static Color deltaColor = new(0.1f, 0.1f, 0.1f, 0);
    private Text component;
    protected void Start()
    {
        component = GetComponent<Text>();
    }

    protected void OnMouseEnter()
    {
        component.color -= deltaColor;
    }

    protected void OnMouseExit()
    {
        component.color += deltaColor;
    }

    protected void OnMouseDown()
    {
        SceneManager.LoadScene(GameData.Player.Sublocation);
    }
}
