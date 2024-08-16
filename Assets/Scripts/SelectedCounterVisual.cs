using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    private GameObject selectedCounter;
    [SerializeField] private ClearCounter clearCounter;

    void Awake()
    {
        selectedCounter = transform.GetChild(0).gameObject;
    }

    void Start()
    {
        Player.OnCounterSelected += SetCounterSelected;   
    }

    private void SetCounterSelected(object sender, ClearCounter e)
    {
        if (e == clearCounter)
        {
            Debug.Log($"clear counter name : {e}");
            if (e != null)
            {
                selectedCounter.SetActive(true);
            }
            else
            {
                selectedCounter.SetActive(false);
            }
        }
        else
        {
            selectedCounter.SetActive(false);
        }
    }

  

    
}
