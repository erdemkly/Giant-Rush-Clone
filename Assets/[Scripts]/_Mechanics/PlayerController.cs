using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]public Rigidbody rb;
    [HideInInspector] public Animator anim;
    [HideInInspector] public GameObject model;
    public float forwardSpeed;

    private void Awake()
    {
        GameManager.Instance.currentPlayer = this;
    }

    void Start()
    {
        Initialize();
        SetAnimBool("Running",true);
    }

    private void Initialize()
    {
        model = transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
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
}