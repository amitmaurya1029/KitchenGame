using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveAnim : MonoBehaviour
{
   [SerializeField] private GameObject fryingParticle;
   [SerializeField] private GameObject stoveOnObject;
   [SerializeField] private CookingCounter cookingCounter;

   private void Start()
   {
        cookingCounter.OnPattyState += SetCookingCounterOn;
   }

    private void SetCookingCounterOn(object sender, PattyState e)
    {
        if (e != PattyState.Ideal)
        {
            fryingParticle.SetActive(true);
            stoveOnObject.SetActive(true);
        }
        else
        {
            fryingParticle.SetActive(false);
            stoveOnObject.SetActive(false);
        }
        
    }

    
}
