using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CookingRecpieSO : ScriptableObject
{
    public KitchenObjectSO RAW;
    public KitchenObjectSO Cooked;
    public KitchenObjectSO Burned;
    public float CookingTimeMax;
}
