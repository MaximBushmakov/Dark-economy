using System.Collections.Generic;
using PlayerSystem;
using UnityEngine;
using WorldSystem;

public class PlaceNPC : MonoBehaviour
{
    public void Start()
    {
        GameData.UpdateTime();
        List<NPC> npc = TimeSystem.GetInstance().GetLocation(GameData.Player.Location)
            .FindNPCInSublocation(GameData.Player.Sublocation);
        for (int i = 0; i < npc.Count; ++i)
        {
            ImageData.CreateNPCObject(npc[i].GetName(), transform.GetChild(i));
        }
    }
}
