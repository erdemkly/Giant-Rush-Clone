using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class RunState : MyState,IState
{
    private float mouseX;
    private float deltaX;

    public RunState()
    {
        
    }
    private void Update()
    {
        print("xxx");
        if (Input.GetMouseButtonDown(0))
        {
            mouseX = Input.mousePosition.x;
            deltaX = 0;
        }else if (Input.GetMouseButton(0))
        {
            deltaX = Input.mousePosition.x-mouseX;
            mouseX = Mathf.Lerp(mouseX,Input.mousePosition.x,0.05f);
        }else if (Input.GetMouseButtonUp(0))
        {
            mouseX = 0;
            deltaX = 0;
        }

        var pos = GameManager.Instance.currentPlayer.transform.position;
        pos.x += deltaX*Time.deltaTime*0.02f;
        pos.x = Mathf.Clamp(pos.x, -2.2f, 2.2f);
        GameManager.Instance.currentPlayer.transform.position = pos;
        
        
        var rot = deltaX;
        rot = Mathf.Clamp(rot, -45, 45);
        GameManager.Instance.currentPlayer.model.transform.DOLocalRotate(new Vector3(0, rot, 0), 0.1f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       
    }

    public void OnDrag(PointerEventData eventData)
    {
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
    }
}
