using PlayerSystem;
using UnityEngine;
using UnityEngine.UI;

public class NotesOpen : ButtonTemplate
{
    [SerializeField] private GameObject _notesMessage;
    public void OnMouseDown()
    {
        OnMouseExit();
        transform.parent.gameObject.SetActive(false);
        // set title
        _notesMessage.transform.GetChild(0).GetComponent<Text>().text = name;
        // set body
        _notesMessage.transform.GetChild(1).GetComponent<InputField>().text = GameData.Notes[name];
        _notesMessage.SetActive(true);
    }
}
