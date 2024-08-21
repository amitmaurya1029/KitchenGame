using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameInput : MonoBehaviour
{
    private InputActionSystem inputActionSystem;
    public event EventHandler OnInteraction;
    public event EventHandler OnCuttingObject;

    void Start()
    {
        inputActionSystem = new InputActionSystem();
        inputActionSystem.Player.Enable();
        inputActionSystem.Player.Interaction.performed += InteractionPerformed;
        inputActionSystem.Player.Attack.performed += Attack;  
        inputActionSystem.Player.Cutting.performed += PickKitchenObject;    
    }

    private void PickKitchenObject(InputAction.CallbackContext context)
    {
        OnCuttingObject?.Invoke(this, EventArgs.Empty);
        Debug.Log($"OnpickEvent got call :");
    }

    private void Attack(InputAction.CallbackContext context)
    {
         Debug.Log($"Attcak got hit");
    }

    private void InteractionPerformed(InputAction.CallbackContext context)
    {
       OnInteraction?.Invoke(this,EventArgs.Empty);
       
    }

  
    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = inputActionSystem.Player.Movement.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        Debug.Log($" here is the vector 2 value  : {inputVector}");
        return inputVector;
    }

   
    
}
