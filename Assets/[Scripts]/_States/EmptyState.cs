using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EmptyState :MyState
{
   public EmptyState()
    {
       
    }

   public override void Loop()
   {
       
   }

   public override void OnPointerDown(PointerEventData eventData)
   {
   }

    public override void OnPointerUp(PointerEventData eventData)
    {
    }

    public override void OnDrag(PointerEventData eventData)
    {
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
    }
}
