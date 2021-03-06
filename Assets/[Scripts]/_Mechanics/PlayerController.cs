using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]public Rigidbody rb;
    [SerializeField] private float velocity;
    void Start()
    {
        Initialize();
        GameManager.Instance.currentPlayer = this;
    }

    private void Initialize()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * velocity;
    }
    

    [Button("Jump")]
    public void Jump()
    {
        rb.AddForce(Vector3.up*100);
    }
}
