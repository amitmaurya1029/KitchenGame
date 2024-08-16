using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass : MonoBehaviour
{
    public virtual void Start()
    {
        Debug.Log($" start function got hit form baseclass CLASS  :");
        
    } 

    public void Interact()
    {
        Debug.Log($" Got the intercation :0");
    }

    public void InteractWithDevice(string deviceName)
    {
        Debug.Log($"Device got activate : {deviceName}");
    }
}
