using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class npcDialog : buttonTemplate
{
    public GameObject interactionButtons;
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
