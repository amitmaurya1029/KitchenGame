using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    private GameObject selectedCounterVisual;
    [SerializeField] private Counter Counter;

    void Awake()
    {
        selectedCounterVisual = transform.GetChild(0).gameObject;
    }

    void Start()
    {
        Player.OnCounterSelected += SetCounterSelected;   
    }

    private void SetCounterSelected(object sender, Counter e)
    {
        if (e == Counter)
        {
            Debug.Log($"clear counter name : {e}");
            if (e != null)
            {
                selectedCounterVisual.SetActive(true);
            }
            else
            {
                selectedCounterVisual.SetActive(false);
            }
        }
        else
        {
            selectedCounterVisual.SetActive(false);
        }
    }

  

    
}
