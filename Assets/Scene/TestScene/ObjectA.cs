using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ObjectA : BaseClass
{
    public override void Start()
    {
        base.Start();
        Debug.Log($" start function got hit form baseclass CLASS  : objecta ");
        
    }


    public void GetObjectAInfo()
    {
        Debug.Log($" objecta has a override start fun");
    }
}
