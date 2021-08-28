using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] Camera c1;
    [SerializeField] Camera c2;
    [SerializeField] Camera c3;
    [SerializeField] GameObject q;
    void Change()
    {
        c1.enabled  = false;
        c2.enabled = true;
    }
     void Change2()
    {
        c2.enabled  = false;
        c3.enabled = true;
        q.SetActive(false);
    }
}
