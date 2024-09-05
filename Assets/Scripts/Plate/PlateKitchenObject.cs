using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{

    // adding the the individual ingredients onto plate to make a whole burger.
    private List<KitchenObjectSO> Ingredient;
    public List<KitchenObjectSO> ValidKitchenObjectsSo;
    public event EventHandler<IngredientEventArgs> OnIngredientAdd;

    public class IngredientEventArgs : EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
        public List<KitchenObjectSO> kitchenObjectSOList;
    }

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
            OnIngredientAdd?.Invoke(this, new IngredientEventArgs {kitchenObjectSO = ingredient, kitchenObjectSOList = Ingredient} );
            return true;
        }
        else
        {
            return false;
        }
    }


    
    
}
