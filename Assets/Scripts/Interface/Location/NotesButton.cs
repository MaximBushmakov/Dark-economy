using UnityEngine;

public class NotesButton : ButtonTemplate
{
    [SerializeField] private GameObject notesButtons;
    public new void Start()
    {
        base.Start();
        notesButtons.SetActive(false);
    }

    public void OnMouseDown()
    {
        notesButtons.SetActive(!notesButtons.activeSelf);
    }
}
