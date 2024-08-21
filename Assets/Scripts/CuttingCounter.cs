using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CuttingCounter : Counter
{
    [SerializeField] private List<CuttingRecpie> cuttingRecpies = new List<CuttingRecpie>(); 

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
         if (HasKitchenObject())
         {
            GameObject OutPutObject = InputOutput();
            SpawnCuttingObject(OutPutObject);
           
            //ClearKitchenObject();
         }

    }

    private GameObject InputOutput()
    {
        foreach(CuttingRecpie recpie  in cuttingRecpies)
        {
            
            Debug.Log($"Sliced gameobject name : 2 {recpie.NormalObject.name} + {GetKitchenObject().GetComponent<KitchenObject>().kitchenObjectSO}");
            if (recpie.NormalObject == GetKitchenObject().GetComponent<KitchenObject>().kitchenObjectSO)
            {
                Debug.Log($"Sliced gameobject name : 1 {recpie.SlicedObject.name}");
                return recpie.SlicedObject.prefab.gameObject;
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
