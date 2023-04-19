using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class toMain : MonoBehaviour
{
    // private Button button;
    // void Start() {
    //     GetComponent<Button>().onClick.AddListener(Action);
    //     Debug.Log(GetComponent<Button>());
    // }

    // Start is called before the first frame update
    public void OnMouseDown()
    {
        Debug.Log("hello");
        SceneManager.LoadScene("main");
    }
}
