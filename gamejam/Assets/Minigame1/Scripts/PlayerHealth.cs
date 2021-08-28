using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int Health = 100;
    [SerializeField] GameObject man;

    [SerializeField] Slider slider;
    void Start()
    {
        slider.maxValue = 100;
        slider.minValue = 0;
    }
    void Update()
    {
        slider.value = Health;
    }
    public void Attacked(int damage)
    {
        Health-=damage;
        if(Health <= 0 )
        {
            man.gameObject.SetActive(false);
            GetComponent<PlayerMovement>().enabled = false;
            Time.timeScale = 0;
            Invoke("Restart",3f);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
  
    
}
