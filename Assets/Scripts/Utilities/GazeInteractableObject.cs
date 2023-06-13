using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class GazeInteractableObject: MonoBehaviour
{
    public bool isBeingGazed = false;
    
    public UnityEvent gazeEnterEvent, gazeClickEvent, gazeUpdateEvent, gazeExitEvent;

    public void OnPointerEnter()
    {
        isBeingGazed = true;
        gazeEnterEvent.Invoke();
    }

    public void OnPointerExit()
    {
        isBeingGazed = false;
        gazeExitEvent.Invoke();
    }

    public void OnPointerClick()
    {
        gazeClickEvent.Invoke();
    }

    private void Update()
    {
        //this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.eulerAngles.x,
        //    this.transform.localRotation.eulerAngles.y + 0.03f,
        //    this.transform.localRotation.eulerAngles.z);
        if (isBeingGazed)
        {
            gazeUpdateEvent.Invoke();
        }
    }
}