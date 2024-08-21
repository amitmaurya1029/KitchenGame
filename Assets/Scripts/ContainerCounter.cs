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
            Debug.Log($"there is a KitchenObject already");
        }
        
    }

}
