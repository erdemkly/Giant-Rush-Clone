using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IState : IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler
{
    
}
