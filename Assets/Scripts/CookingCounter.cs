using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingCounter : Counter
{
    [SerializeField] private CookingRecpieSO cookingRecpieSO;

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
            // has kitchen object
            player.SetKitchenObject(GetKitchenObject());
            GetKitchenObject().SetKitchenObjectParent(player);
            IsContainKitchenObject(false);
            ClearKitchenObject();


        }
    }


    private void CookingMeatPatty()
    {
        // each 3 sec we exchange the gameobject
        // give the cooked patty
        // after 3 sec, give burned patty.


    }


}
