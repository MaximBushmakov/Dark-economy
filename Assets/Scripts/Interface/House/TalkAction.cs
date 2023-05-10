using PlayerSystem;

public class TalkAction : ButtonTemplate
{
    public void OnMouseDown()
    {
        if (GameData.CurTrader.CheckBan() == true)
        {
            //
        }
    }
}