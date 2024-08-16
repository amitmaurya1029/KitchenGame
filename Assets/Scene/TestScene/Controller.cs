using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //[SerializeField] private ObjectA objectA;
    private IElectronicDevice ObjectA;
    private IElectronicDevice objectB;
    void Start()
    {
        //objectA.GetObjectAInfo();
        
        ObjectA.InteractWithDevice("Laptop");
        
        objectB = FindObjectOfType<ObjectB>();
        objectB.InteractWithDevice("mobile");
        
       // baseClass.Interact();   
    }

}
