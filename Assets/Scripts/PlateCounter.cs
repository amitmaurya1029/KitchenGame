using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounter : Counter
{
    [SerializeField] private  KitchenObjectSO Plate;  



    public override void Interaction(Player player)
    {
        if (!HasKitchenObject())
        {
            SetKitchenObject(player.GetKitchenObject());
            GetKitchenObject().SetKitchenObjectParent(this);
            player.ClearKitchenObject();
            player.IsContainKitchenObject(false);
          
        }

        else
        {
            if (HasKitchenObject())
            {
                // has kitchen object
                player.SetKitchenObject(GetKitchenObject());
                GetKitchenObject().SetKitchenObjectParent(player);
                IsContainKitchenObject(false);
                ClearKitchenObject();

            }
            else
            {
                
            }
        }
    }


    
}
