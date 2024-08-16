using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class KitchenObject : MonoBehaviour
{
    public KitchenObjectSO kitchenObjectSO;
    private IKitchenObjectParent KitchenObjectparent;

    public void SetKitchenObjectParent(IKitchenObjectParent KitchenObjectParent)
    {
        this.KitchenObjectparent = KitchenObjectParent;
        KitchenObjectparent.SetKitchenObject(this);
        transform.parent = KitchenObjectParent.GetTargetPoint();
        transform.localPosition = Vector3.zero;
        KitchenObjectparent.IsContainKitchenObject(true);
       // KitchenObjectparent.ClearKitchenObject();
    }

     
}
