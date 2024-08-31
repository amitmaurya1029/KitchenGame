using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlateCounter : Counter
{
    [SerializeField] private  KitchenObjectSO Plate;
    private int spawnTimeMax = 1;  
    private int plateMax = 5;  
    private List<KitchenObject> plates = new List<KitchenObject>(); 
    private float time; 
    
    void Update()
    {
        
        if (plates.Count != plateMax)
        {
            time += Time.deltaTime;
            if (time >= spawnTimeMax)
            {
                KitchenObject instantiatedPlate = Instantiate(Plate.prefab.gameObject.GetComponent<KitchenObject>(), GetTargetPoint());
                plates.Add(instantiatedPlate);
                SetKitchenObject(instantiatedPlate);
                Vector3 platePos = GetTargetPoint().position;
                instantiatedPlate.transform.position = new Vector3(platePos.x, platePos.y * plates.Count * 0.05f + platePos.y, platePos.z);
                time = 0;
            }
            
        }
        else
        {

        }
    }

   

    public override void Interaction(Player player)
    {
        if (!HasKitchenObject() && player.GetKitchenObject() == null)
        {
            GetKitchenObject().SetKitchenObjectParent(player);
            if (plates.Count > 0)
            {
                plates.RemoveAt(plates.Count - 1); 
            }
            else
            {
                plates.RemoveAt(0);
            }    
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
