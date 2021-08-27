using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDefuse : MonoBehaviour
{
    [SerializeField] int BombHealth= 100;
    [SerializeField] int damage = 20;
    PlayerMovement Player;
    void Awake()
    {
       Player =  FindObjectOfType<PlayerMovement>();
    }
   public void DefuseDamage()
   {
       BombHealth -= damage;
       if(BombHealth<=0)
       {
            Player.enabled = false;
            gameObject.SetActive(false);
            Time.timeScale = 0;
       }
   }

}
