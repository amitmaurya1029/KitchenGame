using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //[SerializeField] private ObjectA objectA;
    private IElectronicDevice ObjectA;
    private IElectronicDevice objectB;
    private ObjectB objectb;
    
    void Start()
    {
        
        
        //ObjectA.InteractWithDevice("Laptop");
        
        objectB = FindObjectOfType<ObjectB>();
        objectb = FindObjectOfType<ObjectB>();
        objectB.InteractWithDevice("mobile");
        objectb.Interact();
        
       
    }

}
