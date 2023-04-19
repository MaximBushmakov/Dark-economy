using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello");
        // transform.position = new Vector2(-6, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.position += new Vector3(0, 0.1f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.position += new Vector3(0, -0.1f, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += new Vector3(-0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += new Vector3(0.1f, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        switch(col.name)
        {
            case "roof": {
                col.GetComponent<SpriteRenderer>().enabled = false;
                break;
            }
            case "door": {
                col.transform.Translate(new Vector2(-col.GetComponent<SpriteRenderer>().bounds.size.x * 0.4f, 0));
                Vector3 scale = col.transform.localScale;
                scale.x *= -0.2f;
                col.transform.localScale = scale;
                break;
            }
            default:
                Debug.Log(col.name);
                break;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        switch (col.name)
        {
            case "roof": {
                col.GetComponent<SpriteRenderer>().enabled = true;
                break;
            }
            case "door": {
                Vector3 scale = col.transform.localScale;
                scale.x *= -5;
                col.transform.localScale = scale;
                col.transform.Translate(new Vector2(col.GetComponent<SpriteRenderer>().bounds.size.x * 0.4f, 0));
                break;
            }
            default:
                Debug.Log(col.name);
                break;
        }
    }
}
