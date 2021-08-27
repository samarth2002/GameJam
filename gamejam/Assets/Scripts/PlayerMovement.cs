using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed=1000f;
    
    PlayerRotation playerRotation;

    Rigidbody player;
    Animator anims;
    void Start()
    {
        
        anims = GetComponent<Animator>();
        playerRotation = GetComponentInChildren<PlayerRotation>();
        player = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
      
        float VerticalMove = -moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime;
        float HorizontalMove = moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime;

        if(VerticalMove!=0 || HorizontalMove!=0)
        {
          anims.SetBool("running",true);
        }
        else{
            anims.SetBool("running",false);
        }

        if(VerticalMove > 0)
        {
            playerRotation.RotateLeft();
        }
        else if(VerticalMove<0)
        {
            playerRotation.RotateRight();
        }
        else if(HorizontalMove>0)
        {
            playerRotation.RotateForward();
        }
        else if(HorizontalMove <0)
        {
            playerRotation.RotateBack();
        }
        // if(Input.GetKey(KeyCode.S))
        // {
        //    player.AddForce(Vector3.right*moveSpeed*Time.deltaTime , ForceMode.VelocityChange);
        //    playerRotation.RotateForward();
        // }
        // else if(Input.GetKey(KeyCode.W))
        // {
        //     player.AddForce(Vector3.left*moveSpeed*Time.deltaTime , ForceMode.VelocityChange);
        //     playerRotation.RotateBack();
        // }
        // else if(Input.GetKey(KeyCode.D))
        // {
        //     player.AddForce(0f, 0f , 1f * moveSpeed*Time.deltaTime, ForceMode.VelocityChange);
        //     playerRotation.RotateLeft();
        // }
        // else if(Input.GetKey(KeyCode.A))
        // {
        //     player.AddForce(0f, 0f , -1f * moveSpeed*Time.deltaTime, ForceMode.VelocityChange);
        //     playerRotation.RotateRight();
        // }
        
        player.velocity = new Vector3 (HorizontalMove, player.velocity.y, VerticalMove );
    }
    
}
