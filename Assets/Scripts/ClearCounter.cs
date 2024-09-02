
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : Counter
{
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

            else
            {
                // player has kitchenObject.
                if (player.GetKitchenObject() is PlateKitchenObject)
                {
                    // player has plate
                    KitchenObject kitchenObject = GetKitchenObject();
                    if (player.GetKitchenObject().GetComponent<PlateKitchenObject>().TryAddIngredient(kitchenObject.kitchenObjectSO))
                    {
                        GetKitchenObject().DestroySelf();
                        IsContainKitchenObject(false);
                    }
                    else
                    {
                        // did'nt adde ingredient to plate.
                    }
                    
                }
                else
                {
                    // we have a plate than we can add ingredient to plate

                    if (GetKitchenObject() is PlateKitchenObject)
                    {
                        Debug.Log("yes we got a plate kitchenobject here :");
                        if (GetKitchenObject().GetComponent<PlateKitchenObject>().TryAddIngredient(player.GetKitchenObject().
                        GetComponent<KitchenObject>().kitchenObjectSO))
                        {
                            player.GetKitchenObject().DestroySelf();
                            player.IsContainKitchenObject(false);
                        }
                    }

                }

            }


        }

    }


    

   

}
