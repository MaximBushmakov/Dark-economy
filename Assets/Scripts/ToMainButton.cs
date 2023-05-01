using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToMainButton : ButtonTemplate
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("main");
    }
}
