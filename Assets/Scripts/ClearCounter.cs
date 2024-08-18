
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : Counter, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform Target;
    private KitchenObject kitchenObject;
    private bool isContainKitchenObject;


    void Start()
    {

    }

    public override void Interaction()
    {
        if (!isContainKitchenObject)    
        {
            kitchenObject = Instantiate(kitchenObjectSO.prefab, Target.position, Quaternion.identity).gameObject.GetComponent<KitchenObject>();
            kitchenObject.SetKitchenObjectParent(this);
            isContainKitchenObject = true;
        }
        
    }

    public bool IsContainKitchenObject()
    {
        return isContainKitchenObject;
    }

    public override KitchenObject LendKitchenObject()
    {
        isContainKitchenObject = false;
        return kitchenObject;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public Transform GetTargetPoint()
    {
        return Target;
    }
    public override void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    

    public void DestroyKitchenObject()
    {
        Destroy(this.kitchenObject);
        isContainKitchenObject = false;
        
    }

    public bool IsContainKitchenObject(bool hasKitchenObject)
    {
       isContainKitchenObject = hasKitchenObject;
       return isContainKitchenObject;
    }
}
