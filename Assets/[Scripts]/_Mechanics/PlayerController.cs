using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        GameManager.Instance.currentPlayer = this;
    }

    private void Initialize()
    {
        rb = GetComponent<Rigidbody>();
    }


    [Button("Jump")]
    public void Jump()
    {
        rb.AddForce(Vector3.up*100);
    }
}
