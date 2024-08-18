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
        if (!HasKitchenObject())    
        {
            KitchenObject kitchenObject = Instantiate(kitchenObjectSO.prefab, GetTargetPoint().position, Quaternion.identity).gameObject.GetComponent<KitchenObject>();
            kitchenObject.SetKitchenObjectParent(player);
            OnContainerCounterInteraction?.Invoke(this, EventArgs.Empty);
        }
        
    }

   

   
   
}
