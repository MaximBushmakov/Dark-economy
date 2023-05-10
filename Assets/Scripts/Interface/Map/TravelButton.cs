using PlayerSystem;
using UnityEngine.SceneManagement;
using WorldSystem;

public class TravelButton : ButtonTemplate
{
    public void OnMouseDown()
    {
        if (GameData.Player.Location == RoadData.Roads[GameData.CurRoad].Locations.origin)
        {
            GameData.Player.Location = RoadData.Roads[GameData.CurRoad].Locations.destination;
        }
        else
        {
            GameData.Player.Location = RoadData.Roads[GameData.CurRoad].Locations.origin;
        }

        GameData.UpdateTime(RoadData.Roads[GameData.CurRoad].TravelTime);

        SceneManager.LoadScene(GameData.Player.Location);
    }
}
