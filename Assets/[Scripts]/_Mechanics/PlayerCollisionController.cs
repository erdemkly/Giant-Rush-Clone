using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollisionController : MonoBehaviour
{
    public MySlider mySlider;
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Star":
                mySlider.AddValue(10);
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
