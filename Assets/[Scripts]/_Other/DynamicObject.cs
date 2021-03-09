using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

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
        Star
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
                    Destroy(gameObject);
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
    }

    private void ChangeColorCollision()
    {
        GameManager.Instance.currentPlayer.ChangeColor(currentColor);
    }

    private void StarCollision()
    {
        
    }
}
