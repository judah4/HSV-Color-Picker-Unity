using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorScrollRect : ScrollRect 
{

    public bool Dragging { get; private set; }


    public override void OnInitializePotentialDrag(PointerEventData eventData)
    {
        Dragging = true;
        base.OnInitializePotentialDrag(eventData);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        Dragging = true;
        base.OnBeginDrag(eventData);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        Dragging = true;
        base.OnDrag(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        Dragging = false;
        base.OnEndDrag(eventData);
    }
}
