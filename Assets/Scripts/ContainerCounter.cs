using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : Counter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    public event EventHandler OnContainerCounterInteraction;


    public override void Interaction(Player player)
    {
        if (!player.HasKitchenObject())    
        {
            KitchenObject.SpawnKitchenObject(kitchenObjectSO.prefab.gameObject,GetTargetPoint(),player);
            OnContainerCounterInteraction?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            // player has kitchenObject
            if (player.GetKitchenObject() is PlateKitchenObject)
            {
                if (player.GetKitchenObject().GetComponent<PlateKitchenObject>().TryAddIngredient(kitchenObjectSO))
                {
                    // if it is plate can add kitchenObject to plate  
                    Debug.Log("Yes we have added the ingredient to plate on continer counter :");
                    OnContainerCounterInteraction?.Invoke(this, EventArgs.Empty);
                }

            }
        }
        
    }

}
