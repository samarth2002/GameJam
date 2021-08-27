using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int HitPoints = 1;
    [SerializeField] GameObject Particles;
    int OriginalHitPoints;
    [SerializeField] Score scoreUI;
    bool dead = false;
    void Awake()
    {
        OriginalHitPoints = HitPoints;
    }
    void OnEnable()
    {
        GetComponent<SphereCollider>().enabled = true;
        GetComponent<EnemyAI>().enabled = true;
        Particles.gameObject.SetActive(false);
        HitPoints = OriginalHitPoints;
        dead = false;
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        if(!dead)
        {
            TakeDamage();
        }
        
    }
    void TakeDamage()
    {
        --HitPoints;
        dead = true;
        if(HitPoints <= 0 )
        {
            
            scoreUI.NewScore();
            Particles.gameObject.SetActive(true);
            GetComponent<EnemyAI>().enabled = false;
            Invoke("Death",0.2f);
        }
        
    }
    void Death()
    {
        gameObject.SetActive(false);
    }
}
