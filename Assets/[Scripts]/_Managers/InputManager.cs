using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoSingleton<InputManager> , IPointerDownHandler,IPointerUpHandler,IDragHandler,IEndDragHandler
{

    public IState currentState;

    public void SetState(IState state)
    {
        currentState = state;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        currentState.OnPointerDown(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        currentState.OnPointerUp(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        currentState.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        currentState.OnEndDrag(eventData);
    }
}
