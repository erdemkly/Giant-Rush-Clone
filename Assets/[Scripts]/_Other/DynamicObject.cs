using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using Object = System.Object;

public class DynamicObject : MonoBehaviour
{
    [HideIf("objectType",ObjectType.Star)]
    public MyColor.MyColorEnum currentColor;
    [HideIf("objectType",ObjectType.Star)]
    public Renderer renderer;
    public enum ObjectType
    {
        LittleMan,
        ColorChanger,
        Star,
        Wall
    };

    public ObjectType objectType;

    [HideInInspector]public UnityEvent affectObject;
    private void Start()
    {
        
        switch (objectType)
        {
            case ObjectType.LittleMan: 
                renderer.sharedMaterial = GameManager.Instance.GetMyColorWithEnum(currentColor).material;
                affectObject.AddListener(() =>
            {
                LittleManCollision();
                Destroy(gameObject);
            });
                break;
            case ObjectType.ColorChanger: 
                renderer.sharedMaterial = GameManager.Instance.GetMyColorWithEnum(currentColor).colorChangerMaterial;
                affectObject.AddListener(() =>
                {
                    ChangeColorCollision();
                });
                break;
            case ObjectType.Star: 
                affectObject.AddListener(() =>
                {
                    StarCollision();
                    Destroy(gameObject);
                });
                break;
            case ObjectType.Wall:
                affectObject.AddListener(() =>
                {
                    WallCollision();
                });
                break;
        }
    }

    private void LittleManCollision()
    {
        var isEqual = GameManager.Instance.currentPlayer.currentColor == currentColor;
        var scaleAmount = isEqual ? 0.2f : -0.2f;
        GameManager.Instance.currentPlayer.ChangeScale(scaleAmount);
        UIManager.Instance.AnimText(isEqual?"+1":"-1",transform.position);
        UIManager.Instance.SetSlider(isEqual? 10 : -10);
        
    }

    private void ChangeColorCollision()
    {
        GameManager.Instance.currentPlayer.ChangeColor(currentColor);
    }

    private void StarCollision()
    {
        UIManager.Instance.AddStar(10,transform.position);
    }

    private void WallCollision()
    {
        StartCoroutine(BreakTheWall());
        StartCoroutine(DestroyGameObjectIE(3));
    }

    IEnumerator BreakTheWall()
    {
        GameManager.Instance.currentPlayer.TriggerKickAnim();
        Vector3 explosionPos = GameManager.Instance.currentPlayer.transform.position;
        
        yield return new WaitForSeconds(0.15f);
        
        explosionPos.y = 0.5f;
        explosionPos.z += 0.5f;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, 2);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            
            if (rb != null && hit.tag == "Wall")
            {
                rb.isKinematic = false;
                rb.AddExplosionForce(200, explosionPos, 50, 0);
            }
        }
    }

    IEnumerator DestroyGameObjectIE(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
