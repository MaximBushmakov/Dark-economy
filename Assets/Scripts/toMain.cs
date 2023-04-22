using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class toMain : buttonTemplate
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("main");
    }
}
