using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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

            StartCoroutine(CookingMeatPatty());

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



    private IEnumerator CookingMeatPatty()
    {

        // each 3 sec we exchange the gameobject
        // give the cooked patty
        // after 3 sec, give burned patty.
        
        yield return new WaitForSeconds(cookingRecpieSO.CookingTimeMax);
        FryingPattyState(cookingRecpieSO.Cooked.prefab.GetComponent<KitchenObject>());
        yield return new WaitForSeconds(cookingRecpieSO.CookingTimeMax);
        FryingPattyState(cookingRecpieSO.Burned.prefab.GetComponent<KitchenObject>());



    }


    private void FryingPattyState(KitchenObject meatPatty)
    {
        KitchenObject kitchenObject;
        Destroy(GetKitchenObject().gameObject);
        ClearKitchenObject();
        kitchenObject = Instantiate(meatPatty,GetTargetPoint());
        SetKitchenObject(kitchenObject);
        kitchenObject.SetKitchenObjectParent(this);
        Debug.Log($"kitchenObject Parent 101 : {GetKitchenObject().KitchenObjectparent}");
        
    }


}
