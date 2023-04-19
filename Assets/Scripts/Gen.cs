using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject myPrefab;
    int i = 0;
    // Update is called once per frame
    void Update()
    {
        if (i < 3) {
            Instantiate(myPrefab, new Vector3(i, 0, 0), Quaternion.identity);
        }
        ++i;
    }
}
