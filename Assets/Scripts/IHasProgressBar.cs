using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasProgressBar
{

    public event EventHandler<ProgressBarValue> OnProgressBarIncement;

    public class ProgressBarValue : EventArgs
    {
        public float barFillAmount;
    }  
    
}
