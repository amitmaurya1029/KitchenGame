
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : Counter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interaction()
    {
        if (!HasKitchenObject())    
        {
            KitchenObject kitchenObject = Instantiate(kitchenObjectSO.prefab, GetTargetPoint().position, Quaternion.identity).gameObject.GetComponent<KitchenObject>();
            kitchenObject.SetKitchenObjectParent(this);
        }
        
    }


    

   

}
