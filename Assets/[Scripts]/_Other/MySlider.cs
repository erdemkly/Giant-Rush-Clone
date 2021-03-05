using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class MySlider : MonoBehaviour
{
    public Slider slider;
    public float currentVal;
    
    private void Start()
    {
        SetMaxVal(100);
    }

    public void SetVal(float val)
    {
        currentVal = val;
        currentVal = Mathf.Clamp(currentVal, 0, 100);
        slider.DOValue(val, 0.2f);
    }
    private void SetMaxVal(int val)
    {
        slider.maxValue = val;
    }
    public float GetCurrentVal()
    {
        return slider.value;
    }
    [Button("IncreaseBar")]
    public void IncreaseBar(float val)
    {
        SetVal(currentVal+val);
    }
    [Button("DecreaseBar")]
    public void DecreaseBar(float val)
    {
        SetVal(currentVal-val);
    }
    
    
    
    
}
