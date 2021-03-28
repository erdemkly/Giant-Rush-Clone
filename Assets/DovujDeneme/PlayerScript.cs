using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool isClicked;
    public bool isMyTurn;
    public SliderScript sliderScript;

    void Start()
    {
        isMyTurn = true;
    }

    void Update()
    {
        if (isClicked && isMyTurn)
        {
            if (sliderScript.mySlider.value < 0.5f)
            {
                Debug.Log("punch");
            }
            else
            {
                Debug.Log("double punch");
            }
            isClicked = false;
            isMyTurn = false;
        }
    }
}
