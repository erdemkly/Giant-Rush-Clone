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
    public ParticleSystem bubbleParticle;
    public GameObject starUI;
    public GameObject animStar;
    public Transform parentUI;
    private void OnTriggerEnter(Collider other)
    {
        var dynamicObject = other.GetComponent<DynamicObject>();
        if (dynamicObject != null)
        {
            dynamicObject.affectObject.Invoke();
        }
    }

    

    private void AnimateStar(Transform otherTransform, Vector3 targetPos)
    {
        var myStar = Instantiate(animStar.transform,otherTransform.position,Quaternion.identity);
        myStar.SetParent(parentUI);
        myStar.transform.DOMove(targetPos, .2f).SetEase(Ease.InBounce).OnComplete(() => 
        {
                print("star ok");
        });
    }
    
    private void OnTriggerExit(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    
}
