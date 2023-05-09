using System.Collections.Generic;
using System.Linq;
using PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using WorldSystem;

public class PlaceNPC : MonoBehaviour
{
    public void Start()
    {
        GameData.UpdateTime();
        List<NPC> npc = TimeSystem.GetInstance().GetLocation(GameData.Player.Location)
            .FindNPCInSublocation(GameData.Player.Sublocation);
        GameObject actions = SceneManager.GetActiveScene().GetRootGameObjects().ToList()
                .Find(obj => obj.name == "Canvas")
                .GetComponentsInChildren<Transform>(true).ToList()
                .Find(transform => transform.name == "Action buttons").gameObject;
        for (int i = 0; i < npc.Count; ++i)
        {
            ImageData.CreateNPCObject(npc[i].GetName(), transform.GetChild(i), actions);
        }
    }
}
