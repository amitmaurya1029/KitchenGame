using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent 
{
   public void ClearKitchenObject();
   public bool IsContainKitchenObject(bool hasKitchenObject);
   public void SetKitchenObject(KitchenObject kitchenObject);
   public Transform GetTargetPoint();
   
}
