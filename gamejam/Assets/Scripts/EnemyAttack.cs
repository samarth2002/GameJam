using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damage = 15;
    [SerializeField] PlayerHealth HP;
    [SerializeField] GameObject blast;
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            HP.Attacked(damage);
            blast.SetActive(true);
            Invoke("Destroy" , 0.5f);
        }
    }
    void Destroy()
    {
        blast.SetActive(false);
        gameObject.SetActive(false);
    }
}
