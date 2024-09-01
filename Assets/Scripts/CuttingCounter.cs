using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public class CuttingCounter : Counter, IHasProgressBar
{
    [SerializeField] private List<CuttingRecpieSO> cuttingRecpies = new List<CuttingRecpieSO>(); 
    private int cuttingProgressValue;
    //public event EventHandler<CuttingProgress> OnCuttingProgress;
    public event EventHandler<IHasProgressBar.ProgressBarValue> OnProgressBarIncement;

    public class CuttingProgress : EventArgs
    {
        public float barFillAmount;
    }  

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
            cuttingProgressValue++;
            CuttingRecpieSO cuttingRecpie = InputOutput();
            OnProgressBarIncement?.Invoke(this, new IHasProgressBar.ProgressBarValue {barFillAmount = (float) cuttingProgressValue / cuttingRecpie.MaxCutShot});

            if (cuttingRecpie != null && cuttingProgressValue >= cuttingRecpie.MaxCutShot)
            {
                SpawnCuttingObject(cuttingRecpie.Sliced.prefab.gameObject);
                cuttingProgressValue = 0;
            }
        }

    }

    private CuttingRecpieSO InputOutput()
    {
        foreach(CuttingRecpieSO recpie  in cuttingRecpies)
        {
            if (recpie.Raw == GetKitchenObject().GetComponent<KitchenObject>().kitchenObjectSO)
            {
                return recpie;
            }
        }

        return null;
    }


   


    public void SpawnCuttingObject(GameObject outputObject)
    {
        GetKitchenObject().DestroySelf();
        KitchenObject kitchenObject = KitchenObject.SpawnKitchenObject(outputObject,GetTargetPoint(),this);
        SetKitchenObject(kitchenObject);
        
    }

}
