using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private int Speed = 5;
    private bool isPlayerWalking = false;
    Vector3 hight = new Vector3(0,0.5f,0);
    Vector3 lastInteractionDir;
    public LayerMask layerMask;
    public bool canMove;
    private bool isContainKitchenObject;
    private KitchenObject KitchenObject;
    [SerializeField] private Transform targetPoint;

    private Counter SelectedCounter;

    public static event EventHandler<Counter> OnCounterSelected;

    void Start()
    {
       gameInput.OnInteraction += HandelInteraction;
       gameInput.OnPickKitchenObject += PickKitchenObject;
    }

    void Update()
    {
       HandelMovement(gameInput.GetMovementVector());
       HandelInteraction();
    }

    private void HandelInteraction(object sender, EventArgs e)
    {
        if (SelectedCounter != null)
        {
            SelectedCounter.Interaction(this);
        }
    }

 
    private void HandelInteraction()
    {
        Debug.Log($"Hit info : 1");
        Vector2 vectorInput = gameInput.GetMovementVector();
        Vector3 MoveDir = new Vector3(vectorInput.x, 0,vectorInput.y);
        if(MoveDir != Vector3.zero)
        {
            lastInteractionDir = MoveDir;
        }

        float maxDistance = 1f;
        Debug.Log($"Hit info : 2");
        if (Physics.Raycast(transform.position,lastInteractionDir,out RaycastHit hitInfo,maxDistance,layerMask))
        {
            Debug.Log($"Hit info : 3");
            if (hitInfo.transform.TryGetComponent(out Counter SelectedCounter))
            {
                this.SelectedCounter = SelectedCounter;
                OnCounterSelected?.Invoke(this, SelectedCounter);
            }
            Debug.Log($"Hit info : {hitInfo.transform}");
        }
        else 
        {
            SelectedCounter = null;
             OnCounterSelected?.Invoke(this, SelectedCounter);
        }

    }

    private void HandelMovement(Vector2 inputVector)
    {
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        
        float rayLenght = 0.2f;
         canMove = !Physics.BoxCast(transform.position,transform.localScale * 0.2f, transform.forward, transform.rotation,rayLenght);
        Debug.Log($"canMove  : {canMove}");

       
        if (!canMove)
        {
            // move in x direction.
            Vector3 moveDirX = new Vector3(moveDir.x,0,0);
            canMove = !Physics.BoxCast(transform.position,transform.localScale * 0.2f, moveDirX, transform.rotation,rayLenght);
            if (canMove)
            {
                moveDir = moveDirX;
            }

            else
            {
                Vector3 moveDirZ = new Vector3(0,0,moveDir.z);
                canMove = !Physics.BoxCast(transform.position,transform.localScale * 0.2f,moveDirZ, transform.rotation,rayLenght);
                if (canMove)
                {
                    moveDir = moveDirZ;
                }
                
            }
        }

        if (moveDir != Vector3.zero)
            isPlayerWalking = true;       // tell us the player movement state.

            else
                isPlayerWalking = false;


        if(canMove)
           this.transform.position += moveDir * Time.deltaTime * Speed;

        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotationSpeed * Time.deltaTime);

    }

    public bool IsPlayerWalking()
    {
        return isPlayerWalking;
    }

    void OnDrawGizmos()
    {
      Gizmos.DrawCube(transform.position, Vector3.one);
      
    }

    private void PickKitchenObject(object sender, EventArgs e)
    {
        if (KitchenObject == null)
        {
            KitchenObject = SelectedCounter.LendKitchenObject();
            SelectedCounter.ClearKitchenObject();
            KitchenObject.SetKitchenObjectParent(this);
        }     

        else
        {
            KitchenObject.SetKitchenObjectParent((IKitchenObjectParent)SelectedCounter);
            KitchenObject = null;
            isContainKitchenObject = false;
        }
    }

    public KitchenObject GetKitchenObject()
    {
        return KitchenObject;
    } 

    public void ClearKitchenObject()
    {
        KitchenObject = null;
    }

    public void IsContainKitchenObject(bool hasKitchenObject)
    {
        isContainKitchenObject = hasKitchenObject;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.KitchenObject = kitchenObject;
    }
     public Transform GetTargetPoint()
    {
        return targetPoint;
    }
    public bool HasKitchenObject()
    {
        return isContainKitchenObject;
    }
}
