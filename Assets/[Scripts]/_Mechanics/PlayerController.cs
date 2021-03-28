using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public MyColor.MyColorEnum currentColor;
     [HideInInspector]public Rigidbody rb;
     [HideInInspector] public Animator anim;
     public GameObject model;
     public Renderer meshRenderer;
     public float forwardSpeed;
    

     private void Awake()
     {
         GameManager.Instance.currentPlayer = this;
     }

    void Start()
    {
        Initialize();
        GameManager.Instance.currentPlayer = this;
        //SetAnimBool("Running",true);
    }


    public void ChangeColor(MyColor.MyColorEnum colorEnum)
    {
        meshRenderer.sharedMaterial = GameManager.Instance.GetMyColorWithEnum(colorEnum).material;
        currentColor = colorEnum;
    }
    private void Initialize()
    {
        ChangeColor(currentColor);
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    public void ChangeScale(float val)
    {
        var maxScale = Vector3.one * 1.5f;
        var minScale = Vector3.one * .7f;
        var newScale = gameObject.transform.localScale + Vector3.one * val;
        newScale.x = Mathf.Clamp(newScale.x, minScale.x, maxScale.x);
        newScale.y = newScale.z = newScale.x;
        gameObject.transform.DOScale(newScale, .2f);
    }
    
    private void Update()
    {
        
    }

    public void SetVelocity(Vector3 velo)
    {
        rb.velocity = velo;
    }

    public void SetAnimBool(string animName,bool active)
    {
        anim.SetBool(animName,active);
    }

    public void TriggerKickAnim()
    {
        anim.SetTrigger("Kick");
    }
}
