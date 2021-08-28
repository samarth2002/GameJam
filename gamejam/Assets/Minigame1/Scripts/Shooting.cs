using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] ParticleSystem laser;

    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool SetActivity)
    {
        var emissionModule = laser.emission;
        emissionModule.enabled = SetActivity;
    }
}
