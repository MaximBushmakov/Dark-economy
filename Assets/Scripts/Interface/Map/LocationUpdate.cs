using PlayerSystem;
using UnityEngine;
using UnityEngine.UI;

public class LocationUpdate : MonoBehaviour
{
    public void Start()
    {
        transform.GetChild(0).GetComponent<Text>().text = "Локация: " + GameData.Player.Location;
    }
}
