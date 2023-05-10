using System;
using System.Collections.Generic;
using System.Linq;
using PlayerSystem;
using UnityEngine;
using WorldSystem;

public class Road : MonoBehaviour
{
    private List<Renderer> renderers;
    protected void Start()
    {
        renderers = GetComponentsInChildren<Renderer>().ToList();
    }

    protected void OnMouseEnter()
    {
        foreach (var renderer in renderers)
        {
            renderer.material.color = new Color(0.9f, 0.9f, 0.9f, 1);
        }
    }

    protected void OnMouseExit()
    {
        foreach (var renderer in renderers)
        {
            renderer.material.color = Color.white;
        }
    }

    [SerializeField] private GameObject informationBoard;
    public void OnMouseDown()
    {
        if (!RoadData.Roads.ContainsKey(name))
        {
            throw new Exception("There is no road named " + name);
        }
        GameData.CurRoad = name;
        informationBoard.SetActive(true);
        informationBoard.GetComponent<InfoBoard>().SetText(RoadData.Roads[name].Description);
    }
}
