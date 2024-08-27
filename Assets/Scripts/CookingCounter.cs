using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CookingCounter : Counter
{
    [SerializeField] private List<CookingRecpieSO> cookingRecpieSO = new List<CookingRecpieSO>();
    [SerializeField] private float time;


    void Start()
    {
        Timer();
    }
    void Update()
    {
        // if (time <= 3)
        // {
        //     time += Time.deltaTime;
        // }
    }
    
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


    private void Timer()
    {
        while(time <= 3)
        {
            time += Time.deltaTime;
        }
    } 

    

    private KitchenObjectSO InputOutput(KitchenObjectSO kitchenObject)
    {
        foreach (CookingRecpieSO recpie in cookingRecpieSO)
        {
            if (recpie.Input == kitchenObject)
            {
                return recpie.Output;
            }
            
        }
        return null;

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
