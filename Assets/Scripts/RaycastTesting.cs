using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTesting : MonoBehaviour
{
    [SerializeField] private Transform direction;
    void Update()
    {
      //  Physics.Raycast(transform.position,);
        Debug.DrawRay(transform.position,direction.position,Color.red);
        if (Input.GetKeyDown(KeyCode.T))
        {
         
          transform.forward = new Vector3(0,0,1); 
          direction.forward = new Vector3(0,0,1);

        }

    }
    void Start()
    {
    }

    
}
