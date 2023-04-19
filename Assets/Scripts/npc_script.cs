using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_script : MonoBehaviour
{
    public float MoveSpeed;
    private Rigidbody2D npcRigidbody;
    public bool isMoving;
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;
    private int WalkDirection;
    // Start is called before the first frame update
    void Start()
    {
        npcRigidbody = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter = walkTime;
        ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {  
        if(isMoving) {
            walkCounter -= Time.deltaTime;
            switch (WalkDirection)
            {
                case 0:
                    npcRigidbody.velocity = new Vector2(0, MoveSpeed);
                    break;
                case 1:
                    npcRigidbody.velocity = new Vector2(MoveSpeed, 0);
                    break;
                case 2:
                    npcRigidbody.velocity = new Vector2(0, -MoveSpeed);
                    break;
                case 3:
                    npcRigidbody.velocity = new Vector2(-MoveSpeed, 0);
                    break;
            }
            if(walkCounter < 0){
                isMoving = false;
                waitCounter = waitTime;
            }
        } else{
            npcRigidbody.velocity = Vector2.zero;
            waitCounter -= Time.deltaTime;
            if(walkCounter < 0){
                ChooseDirection();
            }
        }
    }
    public void ChooseDirection(){
        WalkDirection = Random.Range(0, 4);
        isMoving = true;
        walkCounter = walkTime;
    }
}
