using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class RunState : MyState
{
    private float mouseX;
    private float deltaX;
    private PlayerController player;
    private Vector3 pos;
    
    public RunState()
    {
        player = GameManager.Instance.currentPlayer;
    }
    
    public override void  Loop()
    {
        
        SetVelocity();
        SetMovement();
        SetRotation();
    }

    public void SetVelocity()
    {
        player.SetVelocity(new Vector3(
            player.rb.velocity.x, 
            player.rb.velocity.y, 
            player.forwardSpeed));
    }

    public void SetMovement()
    {
        pos = player.transform.position;
        pos.x += deltaX * Time.deltaTime * 0.02f;
        pos.x = Mathf.Clamp(pos.x, -2.2f, 2.2f);
        player.transform.position = pos;
    }

    public void SetRotation()
    {
        var rot = deltaX;
        rot = Mathf.Clamp(rot, -45, 45);
        player.model.transform.DOLocalRotate(new Vector3(0, rot, 0), 0.2f);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        mouseX = eventData.position.x;
        deltaX = 0;
    }

    public override void  OnPointerUp(PointerEventData eventData)
    {
        mouseX = 0;
        deltaX = 0;
    }

    public override void  OnDrag(PointerEventData eventData)
    {
        deltaX = eventData.position.x - mouseX;
        mouseX = Mathf.Lerp(mouseX,eventData.position.x,0.05f);
    }

    public override void  OnEndDrag(PointerEventData eventData)
    {
       
    }
}