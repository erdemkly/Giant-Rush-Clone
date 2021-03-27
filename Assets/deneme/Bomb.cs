using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float radius;
    public float power;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 2);
    }

    [Button]
    public void Explode()
    {
        Vector3 explosionPos = transform.position;
        
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        
        foreach (Collider hit in colliders)
        {
            Debug.Log("sdlkjbsf");
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            
            if (rb != null && hit.tag == "Wall")
            {
                rb.isKinematic = false;
                rb.AddExplosionForce(power, explosionPos, radius, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Explode();
    }
}
