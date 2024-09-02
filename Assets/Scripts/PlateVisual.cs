using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateVisual : MonoBehaviour
{
    [SerializeField] private PlateCounter plateCounter;
    [SerializeField] private  KitchenObjectSO Plate;
    [SerializeField] private Transform target;
    private int maxPlateVisual = 5;
    private List<KitchenObject> plates = new List<KitchenObject>();
     

    void Start()
    {
        plateCounter.OnPlateSpawn += SpawnPlates;
        plateCounter.OnPlateRemove += RemovePlate;
    }

    private void SpawnPlates(object sender, EventArgs e)
    {    
        if (maxPlateVisual != plates.Count)
        {
            KitchenObject instantiatedPlate = Instantiate(Plate.prefab.gameObject.GetComponent<KitchenObject>(), target);
            plates.Add(instantiatedPlate);
            // SetKitchenObject(instantiatedPlate);
            Vector3 platePos = target.position;
            instantiatedPlate.transform.position = new Vector3(platePos.x, platePos.y * plates.Count * 0.05f + platePos.y, platePos.z);
        }
    }


    private void RemovePlate(object sender, EventArgs e)
    {
        if (plates.Count > 0)
        {
            KitchenObject plate = plates[plates.Count - 1].gameObject.GetComponent<KitchenObject>();
            plateCounter.SetKitchenObject(plate);
            plates.Remove(plate);
            //Destroy(plate.gameObject); 

        }

        else
        {
            plates.RemoveAt(0);
        }    
    }
    
}
