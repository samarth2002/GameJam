using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed_side = 500f;
    [SerializeField] float moveSpeed_front = 200f;
    public float yourJumpForce =50f;
    Rigidbody player;
    public bool h_inputswitch = false;
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }
    // void Update()
    // {
    //     GetComponent<Rigidbody>().velocity = new Vector3(4, 0, 0);
    //     if (Input.GetKey(KeyCode.Space))
    //         Physics.gravity = new Vector3(0, 9.81f, 0);

    //     if (Input.GetKey(KeyCode.A))
    //         GetComponent<Rigidbody>().velocity = new Vector3(4, 0, 2);
    //     if (Input.GetKey(KeyCode.D))
    //         GetComponent<Rigidbody>().velocity = new Vector3(4, 0, -2);
    // }
    void FixedUpdate()
    {
        float Horizontal =  -moveSpeed_side*Input.GetAxis("Horizontal")*Time.deltaTime; 
        if(!h_inputswitch)
        {
           player.velocity = new Vector3 (moveSpeed_front*Time.deltaTime, player.velocity.y, Horizontal);
        }
        if(h_inputswitch)
        {
            player.velocity = new Vector3 (moveSpeed_front*Time.deltaTime, player.velocity.y, -Horizontal);
        }
       // float HorizontalMove = moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime;

        // if(VerticalMove!=0 || HorizontalMove!=0)
        // {
        //   anims.SetBool("running",true);
        // }
        // else{
        //     anims.SetBool("running",false);
        // }
        if (Input.GetKeyDown("space"))
        {
        player.AddForce(new Vector3(0, yourJumpForce*Time.deltaTime, 0), ForceMode.Impulse);
        
        }
        
        

    }
}

