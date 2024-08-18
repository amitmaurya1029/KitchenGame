using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : Counter, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform Target;

    private KitchenObject kitchenObject;
    private bool isContainKitchenObject;

    public override void Interaction()
    {
        if (!isContainKitchenObject)    
        {
            kitchenObject = Instantiate(kitchenObjectSO.prefab, Target.position, Quaternion.identity).gameObject.GetComponent<KitchenObject>();
            kitchenObject.SetKitchenObjectParent(this);
            isContainKitchenObject = true;
        }
        
    }

    public override KitchenObject LendKitchenObject()
    {
        isContainKitchenObject = false;
        return kitchenObject;
    }

    public override void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public Transform GetTargetPoint()
    {
        return Target;
    }

    public bool IsContainKitchenObject(bool hasKitchenObject)
    {
        isContainKitchenObject = hasKitchenObject;  
        return isContainKitchenObject; 
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
   
}
