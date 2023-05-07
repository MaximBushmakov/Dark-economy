using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkButton : ButtonTemplate
{
    public new void Start()
    {
        base.Start();
        transform.parent.gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
