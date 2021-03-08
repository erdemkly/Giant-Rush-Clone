using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.Utilities;
using UnityEngine;


public class PlayerCollisionController : MonoBehaviour
{
    public MySlider mySlider;
    public Material playerMat;
    private float _scaleSize = .2f;
    
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Star":
                Destroy(other.gameObject);
                mySlider.AddValue(10);
                break;
            case "LittleMan":
                ControlColor(other.transform.Find("LittleMan").GetComponentInChildren<SkinnedMeshRenderer>().material.color);
                Destroy(other.gameObject);
                break;
        }
    }

    private void ControlColor(Color clr)
    {
        if (playerMat.color == clr)
        {
            ChangeScale(_scaleSize);
        }
        else
        {
            ChangeScale(-_scaleSize);
        }
    }
    private void ChangeScale(float val)
    {
        var maxScale = Vector3.one * 1.5f;
        var minScale = Vector3.one * .7f;
        var newScale = gameObject.transform.localScale + Vector3.one * val;
        newScale.x = Mathf.Clamp(newScale.x, minScale.x, maxScale.x);
        newScale.y = newScale.z = newScale.x;
        gameObject.transform.DOScale(newScale, .2f);
    }
    
    private void OnTriggerExit(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    
}
