using PlayerSystem;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerData : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Text>().text = "Повозка: " + GameData.Player.WagonName + "\n\n" + GameData.Player.Money + " (c)";
    }
}
