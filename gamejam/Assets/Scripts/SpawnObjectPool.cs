using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObjectPool : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] GameObject Enemy;
    [SerializeField] float RespawnDelay = 1f;
    [SerializeField] float Range = 100f;
    [SerializeField][Range(0,50)] int PoolSize = 10;
    [SerializeField] int SpawnSize = 5;
    [SerializeField] GameObject[] pool;
    [SerializeField] Transform ClonesObject;
    [SerializeField] int TotalEnemiesToBeSpawned=30;
    void Awake()
    {
        pool = new GameObject[PoolSize];
        PopulatePoolSpawn();
    }
   
    void PopulatePoolSpawn()
    {
        
        for(int i = 0 ; i < pool.Length; i++)
        {
            
            pool[i] = Instantiate(Enemy , transform.position ,Quaternion.identity);
            pool[i].SetActive(false);   
            pool[i].transform.parent = ClonesObject;
        }
    }
  
    void Start()
    {
        StartCoroutine(Respawn());
    }
  
    void EnableInObjectPoolSpawn()
    {
        for(int i = 0 ; i < pool.Length ; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].transform.position = transform.position; 
                pool[i].SetActive(true);
                TotalEnemiesToBeSpawned--;
                return;
            }

        }
    }
  
   
  
    IEnumerator Respawn()
    {
        //Debug.Log("Respawning now");
        while(TotalEnemiesToBeSpawned>0)
        {
            if(Vector3.Distance(player.position,transform.position) <= Range)
            {
                EnableInObjectPoolSpawn();

            }
            yield return new WaitForSeconds(RespawnDelay);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f , 0f ,0f , 0.75f);
        Gizmos.DrawWireSphere(transform.position , Range);
    }
}
