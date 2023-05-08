using UnityEngine;

public class NotesButton : ButtonTemplate
{
    [SerializeField] private GameObject notesButtons;

    public void OnMouseDown()
    {
        notesButtons.SetActive(!notesButtons.activeSelf);
    }
}
