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
        imageBar.transform.parent.gameObject.SetActive(true);
    }

   
    private void Hide()
    {
        imageBar.transform.parent.gameObject.SetActive(false);
    }

    
}
