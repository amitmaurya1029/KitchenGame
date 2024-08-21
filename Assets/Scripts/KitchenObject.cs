using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public enum SliceableObject {Sliceable, NotSliceable}
public class KitchenObject : MonoBehaviour
{
    public KitchenObjectSO kitchenObjectSO;
    public IKitchenObjectParent KitchenObjectparent;
    public SliceableObject IsSliceableObject;
    

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObject)
    {
        this.KitchenObjectparent = kitchenObject;
        KitchenObjectparent.SetKitchenObject(this);
        transform.parent = KitchenObjectparent.GetTargetPoint();
        transform.localPosition = Vector3.zero;
        KitchenObjectparent.IsContainKitchenObject(true);
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    public static KitchenObject SpawnKitchenObject(GameObject kitchenObjectPrefab, Transform target, IKitchenObjectParent parent)
    {
        KitchenObject kitchenObject = Instantiate(kitchenObjectPrefab, target.position, Quaternion.identity).
        gameObject.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(parent);
        return kitchenObject;
    }
     
}
