using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public bool isPlantable = false;
    [SerializeField] GameObject C4;
    [SerializeField] float BombTimer = 40f;
   // [SerializeField] GameObject[] setstatic;
    [SerializeField] Animator park;
    [SerializeField] GameObject pool;

    [SerializeField] float spawnTime=5f;
    [SerializeField] Canvas BMBUI;
    public int planted = 0;
    void Update()
    {
        Plant();
    }
    void Plant()
    {
        if(Input.GetKeyDown(KeyCode.E)&&isPlantable && planted==0)
        {
            C4.transform.position = transform.position;
            C4.SetActive(true);
            // foreach(GameObject element in setstatic)
            // {
            //     element.gameObject.isStatic = false;
            // }
            
            park.SetTrigger("down");
            Invoke("PoolSpawn",spawnTime);
            Invoke("Explosion",BombTimer);
            BMBUI.enabled = false;
            planted++;
        }
    }

    void PoolSpawn()
    {
        pool.SetActive(true);
    }
    void Explosion()
    {
        //C4.GetComponentInChildren<ParticleSystem>().Play();

    }
}
