using UnityEngine;

public class NPCDialogOpen : ButtonTemplate
{
    [SerializeField] private GameObject interactionButtons;
    protected new void Start()
    {
        base.Start();
        interactionButtons.SetActive(false);
    }

    public void OnMouseDown()
    {
        interactionButtons.SetActive(true);
    }
}
