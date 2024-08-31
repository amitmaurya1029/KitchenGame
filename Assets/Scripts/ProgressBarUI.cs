using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressBarObject;
    [SerializeField] private UnityEngine.UI.Image imageBar;
    [SerializeField] private IHasProgressBar progressBarCounter;

    void Start()
    {
        progressBarCounter = hasProgressBarObject.GetComponent<IHasProgressBar>();
        if (progressBarCounter == null)
        {
            Debug.LogError("does not contain progressbar interface");
        }    
        progressBarCounter.OnProgressBarIncement += FillProgressBar;
        Hide();
    }

    private void FillProgressBar(object sender, IHasProgressBar.ProgressBarValue e)
    {
        imageBar.fillAmount = e.barFillAmount;
        if (e.barFillAmount == 1)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }
   
    private void Show()
    {
        transform.gameObject.SetActive(true);
    }

   
    private void Hide()
    {
       transform.gameObject.SetActive(false);
    }

    
}
