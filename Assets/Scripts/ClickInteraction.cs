using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickInteraction : MonoBehaviour
{
    public UnityEvent onMouseDownEvent, onMouseDragEvent, onMouseUpEvent;

    public void OnMouseDown()
    {
        onMouseDownEvent.Invoke();
    }

    private void OnMouseDrag()
    {
        onMouseDragEvent.Invoke();
    }

    public void OnMouseUp()
    {
        onMouseUpEvent.Invoke();
    }
}
