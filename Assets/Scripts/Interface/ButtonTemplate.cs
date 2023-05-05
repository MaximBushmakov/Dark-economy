using UnityEngine;

public class ButtonTemplate : MonoBehaviour
{
    private Renderer _renderer;
    protected void Start()
    {
        _renderer = GetComponent<Renderer>();
    }
    protected void OnMouseEnter()
    {
        _renderer.material.color = new Color(0.9f, 0.9f, 0.9f, 1);
    }

    protected void OnMouseExit()
    {
        _renderer.material.color = Color.white;
    }
}
