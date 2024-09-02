using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{

    // adding the the individual ingredients onto plate to make a whole burger.
    public List<KitchenObjectSO> Ingredient;
    public List<KitchenObjectSO> ValidKitchenObjectsSo;

    void Awake()
    {
        Ingredient = new List<KitchenObjectSO>();
    }

    public bool TryAddIngredient(KitchenObjectSO ingredient)
    {
        Debug.Log("it entered here : 1");
        
        if (Ingredient.Contains(ingredient))
        {
            return false;
        }
        if (ValidKitchenObjectsSo.Contains(ingredient))
        {
            Ingredient.Add(ingredient);
            return true;
        }
        else
        {
            return false;
        }
    }


    
    
}
