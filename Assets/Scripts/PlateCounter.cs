using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlateCounter : Counter
{
    private int spawnTimeMax = 1;   
    public event EventHandler OnPlateSpawn;
    public event EventHandler OnPlateRemove;
    private float time; 
    
    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawnTimeMax)
        {
            OnPlateSpawn?.Invoke(this, EventArgs.Empty);
            time = 0;
        }
        else
        {

        }
    }

    public override void Interaction(Player player)
    {
        if (!HasKitchenObject() && player.GetKitchenObject() == null)
        {
            OnPlateRemove?.Invoke(this,EventArgs.Empty);
           // GetKitchenObject().SetKitchenObjectParent(player);
            // if (plates.Count > 0)
            // {
            //     plates.RemoveAt(plates.Count - 1); 
            // }
            // else
            // {
            //     plates.RemoveAt(0);
            // }    
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
