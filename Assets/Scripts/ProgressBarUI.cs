using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image imageBar;
    
    [SerializeField] private CuttingCounter cuttingCounter;

    void Start()
    {
        cuttingCounter.OnCuttingProgress += FillProgressBar;
        Hide();
    }

    private void FillProgressBar(object sender, CuttingCounter.CuttingProgress e)
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
