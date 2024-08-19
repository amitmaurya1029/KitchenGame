using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent 
{
   public void ClearKitchenObject();
   public void IsContainKitchenObject(bool hasKitchenObject);
   public bool HasKitchenObject();
   public void SetKitchenObject(KitchenObject kitchenObject);
   public Transform GetTargetPoint();
   public KitchenObject GetKitchenObject();

   
}
