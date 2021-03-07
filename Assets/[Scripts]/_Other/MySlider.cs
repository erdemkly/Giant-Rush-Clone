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
    public Gradient gradient;
    public Image fill;
    private int maxVal;
    private int currentVal;

    [ShowInInspector,PropertyRange(0,"maxVal")]
    public int CurrentVal
    {
        get => currentVal;
        set
        {
            value = Mathf.Clamp(value, 0, maxVal);
            currentVal = value;
            slider.DOValue(value, 0.2f);
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        SetMaxVal();
    }
    
    private void SetMaxVal()
    {
        maxVal = (int)slider.maxValue;
        fill.color = gradient.Evaluate(0f);
    }
    
    public void SetValue(int val)
    {
        CurrentVal = val;
    }
    [Button]
    public void AddValue(int val)
    {
        SetValue(currentVal+val);
    }
    
    
    
    
    
    
}
