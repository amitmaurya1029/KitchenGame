using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectB : BaseClass, IElectronicDevice
{
    public override void Start()
    {
        base.Start();
        Debug.Log($" start function got hit form baseclass CLASS  : objectb ");
       // Interact();
        // InteractWithDevice("Cell phone");
        ClassS.ReleaseFlares();
    }


    public void SetParentOfThisClass()
    {
        Debug.Log($"object b parent got set :");
    }

    public override void Interact()
    {
        Debug.Log($" Got the intercation :0 only interaction override fun got called : ");
    }


}
