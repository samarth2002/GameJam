using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] GameObject Enemy;
    [SerializeField] float RespawnDelay = 2f;
    [SerializeField][Range(0,50)] int PoolSize = 10;
    [SerializeField] int SpawnSize = 5;
    [SerializeField] GameObject[] pool;
    [SerializeField] Transform[] Spawns;
    [SerializeField] Transform SpawnPoints;
    [SerializeField] int SpawnDistance = 40;
    Vector3[] pos;

    void Awake()
    {
        Spawns = new Transform[SpawnSize];
        pos = new Vector3[PoolSize];
        pool = new GameObject[PoolSize];
         for(int i = 0 ; i < pool.Length ; i++)
         {
             GetNewPosRandom(i);

        }
        PopulatePoolRandom();
    }
   
  
    void PopulatePoolRandom()
    {
        
        for(int i = 0 ; i < pool.Length; i++)
        {
            pool[i] = Instantiate(Enemy , pos[i],Quaternion.identity);
            pool[i].SetActive(false);
        }
    }
    void Start()
    {
         
        StartCoroutine(Respawn());
    }
  
    // void EnableInObjectPoolSpawn()
    // {
    //     for(int i = 0 ; i < pool.Length ; i++)
    //     {
    //         if(pool[i].activeInHierarchy == false)
    //         {
    //             pool[i].transform.position = SpawnPoints.position; 
    //             pool[i].SetActive(true);
    //             return;
    //         }

    //     }
    // }
   void EnableInObjectPoolRandom()
    {
        for(int i = 0 ; i < pool.Length ; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                GetNewPosRandom(i);
                pool[i].transform.position = pos[i]; 
                pool[i].SetActive(true);
                return;
            }

        }
    }
   
    private void GetNewPosRandom(int i)
    {
        do
        {
            pos[i] = new Vector3(Random.Range(player.position.x - SpawnDistance, player.position.x + SpawnDistance), 0, Random.Range(player.position.z - SpawnDistance, player.position.z + SpawnDistance));
        } while (Vector3.Distance(pos[i], player.position) <= SpawnDistance-10);
    }

    IEnumerator Respawn()
    {
        Debug.Log("Respawning now");
        while(true)
        {
            EnableInObjectPoolRandom();
            yield return new WaitForSeconds(RespawnDelay);
        }
    }
     void BackToPosition(GameObject A,int i)
     {
         A.transform.position = (player.position + pos[i]);
     }
}
