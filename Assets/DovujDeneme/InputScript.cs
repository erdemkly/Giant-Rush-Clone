using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputScript : MonoBehaviour, IPointerDownHandler
{
    public SliderScript sliderScript;
    public PlayerScript playerScript;

    public void OnPointerDown(PointerEventData eventData)
    {
        sliderScript.IncreaseSlider(0.2f);
        playerScript.isClicked = true;
    }
}
