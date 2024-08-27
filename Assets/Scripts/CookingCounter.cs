using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public enum PattyState {Ideal, Cooked, Burned}
public class CookingCounter : Counter
{
    private PattyState pattyState = PattyState.Ideal;
    [SerializeField] private List<CookingRecpieSO> cookingRecpieSO = new List<CookingRecpieSO>();
    [SerializeField] private float time;
    [SerializeField] private Transform target;

    public event EventHandler<PattyState> OnPattyState;


    void Start()
    {
        Timer();
    }

    void Update()
    {
        switch (pattyState)
        {
            case PattyState.Ideal:
            break;

            case PattyState.Cooked:
                Timer();
                if (time >= 3)
                {
                    ChangePattyState(InputOutput(GetKitchenObject().kitchenObjectSO));
                    OnPattyState.Invoke(this, pattyState);
                }
                break;

            case PattyState.Burned:
                Timer();
                if (time >= 3)
                {
                    ChangePattyState(InputOutput(GetKitchenObject().kitchenObjectSO));
                }
                break;
        }
       
    }

    private void ChangePattyState(KitchenObjectSO patty)
    {
        Debug.Log($"patty name : {patty}");
        KitchenObjectSO kitchenObject = patty;
        Destroy(GetKitchenObject().gameObject);
        KitchenObject.SpawnKitchenObject(kitchenObject.prefab.gameObject, GetTargetPoint(), this);
        pattyState = PattyState.Burned;
        time = 0;
    }

    public override void Interaction(Player player)
    {
        if (!HasKitchenObject())
        {
            SetKitchenObject(player.GetKitchenObject());
            GetKitchenObject().SetKitchenObjectParent(this);
            player.ClearKitchenObject();
            player.IsContainKitchenObject(false);
            pattyState= PattyState.Cooked;
             OnPattyState.Invoke(this, pattyState);

        }

        else
        {
            // has kitchen object
            player.SetKitchenObject(GetKitchenObject());
            GetKitchenObject().SetKitchenObjectParent(player);
            IsContainKitchenObject(false);
            ClearKitchenObject();


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

    private void Timer()
    {
        if (time <= 3)
        {
            time += Time.deltaTime;
        }
    } 





}
