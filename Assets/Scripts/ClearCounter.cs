
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : Counter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

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
            else
            {
                // player has NO kitchenobject
                // player.SetKitchenObject(GetKitchenObject());
                // GetKitchenObject().SetKitchenObjectParent(player);

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


    

   

}
