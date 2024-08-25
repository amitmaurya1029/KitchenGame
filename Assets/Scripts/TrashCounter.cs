using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : Counter
{
    public override void Interaction(Player player)
    {
        if (player.HasKitchenObject())
        {
            Destroy(player.GetKitchenObject().gameObject);
            player.ClearKitchenObject();
            player.IsContainKitchenObject(false);

        }
        else
        {
            Debug.Log($"does not containg an kitchenobject");
        }
    }
}
