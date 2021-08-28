using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
   // [SerializeField]Animator animator;
    [SerializeField] GameObject blast;

    [SerializeField] GameObject body;
    
    [HideInInspector]
    public float targetDistance = Mathf.Infinity;
    
    bool isProvoked = false;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void OnEnable()
    {
        blast.gameObject.SetActive(false);
    }
    
    void Update()
    {
        targetDistance = Vector3.Distance(target.position , transform.position);
        if(isProvoked)
        {
            EngageTarget();
        }
        else if(targetDistance <= chaseRange)
        {
            body.SetActive(true);   
            isProvoked = true;
        }
        if(targetDistance > chaseRange)
        {
            if(body.activeInHierarchy==true)
            {
                isProvoked = false;
                Debug.Log("off");
                body.SetActive(false);
            }
        }
    }

    private void EngageTarget()
    {     
        navMeshAgent.SetDestination(target.position);   
    }
    

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f , 0f ,0f , 0.8f);
        Gizmos.DrawWireSphere(transform.position , chaseRange);
    }
}
