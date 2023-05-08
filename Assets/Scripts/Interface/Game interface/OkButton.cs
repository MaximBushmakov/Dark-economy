using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkButton : ButtonTemplate
{
    public void OnMouseDown()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
