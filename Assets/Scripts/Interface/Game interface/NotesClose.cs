using PlayerSystem;
using UnityEngine;
using UnityEngine.UI;

public class NotesClose : MonoBehaviour
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
    public void OnMouseDown()
    {
        GameData.Notes[transform.parent.GetChild(0).GetComponent<Text>().text] =
            transform.parent.GetChild(1).GetComponent<InputField>().text;
        transform.parent.gameObject.SetActive(false);
    }
}