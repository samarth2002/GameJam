using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] ObjectPool objectPool;

    [SerializeField] GameObject bomb;
    [SerializeField] Canvas BMBUI;
    void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Start" )
        {
            Debug.Log("Starting game");
            objectPool.gameObject.SetActive(true);
        }
        if(other.gameObject.tag == "Bomb" && GetComponent<Bomb>().isPlantable==false && GetComponent<Bomb>().planted==0)
        {
            bomb.SetActive(false);
          
        }
        if(other.gameObject.tag=="BombSite")
        {
            BMBUI.enabled = true;
            GetComponent<Bomb>().isPlantable = true;
            Debug.Log("BOMBSITE");       
         }
        else
        {
          GetComponent<Bomb>().isPlantable = false;
        }
        
    }

   
}
