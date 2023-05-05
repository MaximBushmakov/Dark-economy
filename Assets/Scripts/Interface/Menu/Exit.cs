using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : ButtonTemplate
{
    private void OnMouseDown()
    {
        Application.Quit();
    }
}
