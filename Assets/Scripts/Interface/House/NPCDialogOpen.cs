using UnityEngine;

public class NPCDialogOpen : ButtonTemplate
{
    private GameObject _interactionButtons;
    protected new void Start()
    {
        base.Start();
        _interactionButtons = GameObject.Find("Action buttons");
    }

    public void OnMouseDown()
    {
        _interactionButtons.SetActive(!_interactionButtons.activeSelf);
    }
}
