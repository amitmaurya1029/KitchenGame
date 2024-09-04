using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable] 
    public class Ingredient
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject kitchenObject;
    } 

    [SerializeField] private PlateKitchenObject plateKitchenObject;
    public List<Ingredient> ingredients = new List<Ingredient>();

    void Start()
    {
        plateKitchenObject.OnIngredientAdd += UpdateTheBurgerVisual;
        foreach (Ingredient gameObject in ingredients)
        {
            gameObject.kitchenObject.gameObject.SetActive(false);

        }
    }

    private void UpdateTheBurgerVisual(object sender, KitchenObjectSO e)
    {
        foreach (var item in ingredients)
        {
            if (item.kitchenObjectSO == e)
            {
                item.kitchenObject.SetActive(true);
            } 
            
        }
    }

  
   
}
