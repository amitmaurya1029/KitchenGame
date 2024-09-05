using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class SingleIconUI : MonoBehaviour
{
   [SerializeField] private UnityEngine.UI.Image image;

   public void SetIcon(KitchenObjectSO kitchenObjectSO)
   {
        image.sprite = kitchenObjectSO.sprite;
   }
}
