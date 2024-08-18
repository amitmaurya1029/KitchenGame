using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class KitchenObject : MonoBehaviour
{
    public KitchenObjectSO kitchenObjectSO;
    public IKitchenObjectParent KitchenObjectparent;
    

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObject)
    {
        this.KitchenObjectparent = kitchenObject;

        KitchenObjectparent.SetKitchenObject(this);
        transform.parent = KitchenObjectparent.GetTargetPoint();
        transform.localPosition = Vector3.zero;
        KitchenObjectparent.IsContainKitchenObject(true);
       // KitchenObjectparent.ClearKitchenObject();
    }

     
}
