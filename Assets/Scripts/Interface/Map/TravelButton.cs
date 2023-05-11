using PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using WorldSystem;
using static WorldSystem.GlobalNames;

public class TravelButton : ButtonTemplate
{
    public void OnMouseDown()
    {
        WorldSystem.Road cur = RoadData.Roads[GameData.CurRoad];
        if (GameData.Player.Location == cur.Locations.origin)
        {
            GameData.Player.Location = cur.Locations.destination;
        }
        else
        {
            GameData.Player.Location = cur.Locations.origin;
        }


        for (int i = 0; i < cur.DangerLevel; ++i)
        {
            TimeSystem.GetInstance().AddEvent(
                AllLocalEvents.GetInstance().GetRandomEvent(
                    System.Math.Max(GameData.Player.Luck - cur.DangerLevel, 0), RoadName
            ));
        }

        GameData.UpdateTime(RoadData.Roads[GameData.CurRoad].TravelTime);
    }
}
