using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider mySlider;

    void Start()
    {
        mySlider = GetComponent<Slider>();
    }

    void Update()
    {
        if (mySlider.value > 0)
        {
            DecreaseSlider(0.5f * Time.deltaTime);
        }
    }

    public void IncreaseSlider(float value)
    {
        mySlider.value += value;
    }
    
    public void DecreaseSlider(float value)
    {
        mySlider.value -= value;
    }
}
