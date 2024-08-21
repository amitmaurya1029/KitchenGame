using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CuttingCounter : Counter
{
    [SerializeField] private List<CuttingRecpieSO> cuttingRecpies = new List<CuttingRecpieSO>(); 

    public override void Interaction(Player player)
    {
         if (!HasKitchenObject())
        {
            // Has no kitchen object 
            if (player.HasKitchenObject())
            {
                // player has kitchenobject
                SetKitchenObject(player.GetKitchenObject());
                GetKitchenObject().SetKitchenObjectParent(this);
                player.IsContainKitchenObject(false);
                player.ClearKitchenObject();

            }
            else {

            }
        }

        else
        {
            // has kitchen object
            if (!player.HasKitchenObject())
            {
                player.SetKitchenObject(GetKitchenObject());
                GetKitchenObject().SetKitchenObjectParent(player);
                IsContainKitchenObject(false);
                ClearKitchenObject();
            }

            else{
                // player has kitchenObject.
            }
        }
        
    }

    public override void CuttingkitchenObject()
    {
         if (HasKitchenObject() && GetKitchenObject().IsSliceableObject != SliceableObject.NotSliceable)
         {
           SpawnCuttingObject(InputOutput());
         }

    }

    private GameObject InputOutput()
    {
        foreach(CuttingRecpieSO recpie  in cuttingRecpies)
        {
            if (recpie.Raw == GetKitchenObject().GetComponent<KitchenObject>().kitchenObjectSO)
            {
                return recpie.Sliced.prefab.gameObject;
            }
        }

        return null;
    }

    public void SpawnCuttingObject(GameObject outputObject)
    {
        GetKitchenObject().DestroySelf();
        KitchenObject kitchenObject = Instantiate(outputObject, GetTargetPoint().position, Quaternion.identity).
        gameObject.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(this);
        SetKitchenObject(kitchenObject);
        
    }

}
