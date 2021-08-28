using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Defuser : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent nav;
    float distance;
    [SerializeField] Transform bomb;
    [SerializeField] GameObject particle;
    [SerializeField] BombDefuse bmb;
    [SerializeField] float fireRate = 5f;
    
    float nextTimeToShoot = 0f;
    void OnEnable()
    {
        particle.SetActive(false);
    }
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position , bomb.position);
       
        transform.LookAt(bomb);
        if(nav.stoppingDistance >= distance)
        {
            
            particle.SetActive(true);
            if(nextTimeToShoot <=Time.time)
            {
                nextTimeToShoot = Time.time + 1f/fireRate;
                 Debug.Log("firing");
                bmb.DefuseDamage();
    
            }
       }
        
    }
  
       
}
