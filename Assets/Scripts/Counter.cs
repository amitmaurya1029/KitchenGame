using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour,IKitchenObjectParent
{
    private KitchenObject kitchenObject;

    [SerializeField] private Transform Target;
    private bool isContainKitchenObject;

    public GameObject AmitObject;

    public virtual void Interaction(Player player)
    {

    }

    public KitchenObject LendKitchenObject()
    {
        isContainKitchenObject = false;
        return kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public  void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public Transform GetTargetPoint()
    {
        return Target;
    }

    public void IsContainKitchenObject(bool hasKitchenObject)
    {
        isContainKitchenObject = hasKitchenObject;   
    }

    public bool HasKitchenObject()
    {
        return isContainKitchenObject;
    } 

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
    
}
