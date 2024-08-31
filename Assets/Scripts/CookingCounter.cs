using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public enum PattyState {Ideal, Cooking, Cooked, Burned}

public class CookingCounter : Counter, IHasProgressBar
{
    private PattyState pattyState = PattyState.Ideal;
    [SerializeField] private List<CookingRecpieSO> cookingRecpieSO = new List<CookingRecpieSO>();
    [SerializeField] private float time;
    [SerializeField] private Transform target;


    public event EventHandler<PattyState> OnPattyState;
    public event EventHandler<IHasProgressBar.ProgressBarValue> OnProgressBarIncement;

    void Start()
    {
        
    }

    void Update()
    {
        switch (pattyState)
        {
            case PattyState.Ideal:
            break;

            case PattyState.Cooking:
                time += Time.deltaTime;
                OnProgressBarIncement.Invoke(this,new IHasProgressBar.ProgressBarValue{barFillAmount = time/cookingRecpieSO[0].CookingTimeMax});
                if (time >= cookingRecpieSO[0].CookingTimeMax)
                {
                    ChangePattyState(InputOutput(GetKitchenObject().kitchenObjectSO));
                    pattyState = PattyState.Cooked;
                    OnPattyState?.Invoke(this, pattyState);
                    OnProgressBarIncement.Invoke(this,new IHasProgressBar.ProgressBarValue{barFillAmount = 0});
                }

                break;

            case PattyState.Cooked:
                time += Time.deltaTime;
                 OnProgressBarIncement.Invoke(this,new IHasProgressBar.ProgressBarValue{barFillAmount = time/cookingRecpieSO[1].CookingTimeMax});
                if (time >= cookingRecpieSO[1].CookingTimeMax)
                {
                    ChangePattyState(InputOutput(GetKitchenObject().kitchenObjectSO));
                    pattyState = PattyState.Burned;
                    OnPattyState?.Invoke(this, pattyState);
                    OnProgressBarIncement.Invoke(this,new IHasProgressBar.ProgressBarValue{barFillAmount = 1});
                }
              
                break;

            case PattyState.Burned:
                
                pattyState = PattyState.Ideal;
                OnPattyState?.Invoke(this, pattyState);
                break;
        }
       
    }

    private void ChangePattyState(KitchenObjectSO patty)
    {
        KitchenObjectSO kitchenObject = patty;
        GetKitchenObject().DestroySelf();
        KitchenObject.SpawnKitchenObject(kitchenObject.prefab.gameObject, GetTargetPoint(), this);
        time = 0;
    }

    public override void Interaction(Player player)
    {
        if (!HasKitchenObject() && player.GetKitchenObject().kitchenObjectSO == cookingRecpieSO[0].Input)
        {
            SetKitchenObject(player.GetKitchenObject());
            GetKitchenObject().SetKitchenObjectParent(this);
            player.ClearKitchenObject();
            player.IsContainKitchenObject(false);
            pattyState= PattyState.Cooking;
            OnPattyState.Invoke(this, pattyState);


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
                pattyState = PattyState.Ideal;
                OnPattyState.Invoke(this, pattyState);
                OnProgressBarIncement.Invoke(this,new IHasProgressBar.ProgressBarValue{barFillAmount = 1});

            }
            else
            {
                
            }
        }
    }

   
    private KitchenObjectSO InputOutput(KitchenObjectSO kitchenObject)
    {
        foreach (CookingRecpieSO recpie in cookingRecpieSO)
        {
            if (recpie.Input == kitchenObject)
            {
                return recpie.Output;
            }
            
        }
        return null;

    }


}
