using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public void RotateRight()
    {
        transform.localRotation = Quaternion.Euler(0 , 90, 0);
    }
    public void RotateLeft()
    {
        transform.localRotation = Quaternion.Euler(0 , 270, 0);
    }
    public void RotateForward()
    {
        transform.localRotation = Quaternion.Euler(0 , 0, 0);
    }
    public void RotateBack()
    {
        transform.localRotation = Quaternion.Euler(0 , 180, 0);
    }
}
