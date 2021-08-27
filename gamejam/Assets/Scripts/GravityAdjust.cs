using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAdjust : MonoBehaviour
{
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision other)
    {
       
        if(other.gameObject.layer==8)
        {
           // Debug.Log("ground");
            rb.constraints = RigidbodyConstraints.FreezeRotation |  RigidbodyConstraints.FreezePositionY;
        }
        else if(other.gameObject.layer==9)
        {
            rb.constraints =  RigidbodyConstraints.FreezeRotation;
        }
    }
}
