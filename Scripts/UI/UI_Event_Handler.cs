using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Event_Handler : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    public Action<PointerEventData> OnDragHandler = null;
    public Action<PointerEventData> OnClickHandler = null;
    public void OnDrag(PointerEventData eventData)
    {
        if(OnDragHandler != null)
        {
            OnDragHandler.Invoke(eventData);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(OnClickHandler != null)
        {
            OnClickHandler.Invoke(eventData);
        }
    }
}
