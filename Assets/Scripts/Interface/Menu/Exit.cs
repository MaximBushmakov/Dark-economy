using UnityEngine;
using WorldSystem;

public class Exit : ButtonTemplate
{
    public void OnMouseDown()
    {
        TimeSystem.GetInstance().EndLog();
        Application.Quit();
    }
}
