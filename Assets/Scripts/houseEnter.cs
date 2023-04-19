using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class houseEnter : MonoBehaviour
{
    private new Renderer renderer;
    void Start() {
        renderer = GetComponent<Renderer>();
        Debug.Log(renderer);
    }

    void OnMouseEnter() {
        renderer.material.color = Color.yellow;
    }

    void OnMouseExit() {
        renderer.material.color = Color.white;
    }

    void OnMouseDown() {
        SceneManager.LoadScene(name);
    }
}
