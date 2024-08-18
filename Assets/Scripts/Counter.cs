using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private KitchenObject kitchenObject;

    public virtual void Interaction()
    {

    }

    public virtual KitchenObject LendKitchenObject()
    {
        return kitchenObject;
    }

    public virtual void ClearKitchenObject()
    {
        
    }
}
