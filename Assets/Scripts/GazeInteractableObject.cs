using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class GazeInteractableObject: MonoBehaviour
{
    public bool isBeingGazed = false;
    public bool isTriggered = false;
    
    public float gazeTime = 0f;
    public float clickGazeThreshold = 2f;       // after 2 seconds -> count as a click

    public UnityEvent gazeClickEvent, gazeExitEvent;

    public void OnPointerEnter()
    {
        gazeTime = 0f;
        isBeingGazed = true;
    }

    public void OnPointerExit()
    {
        gazeTime = 0f;
        isTriggered = false;
        isBeingGazed = false;
        gazeExitEvent.Invoke();
    }

    private void Update()
    {
        //this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.eulerAngles.x,
        //    this.transform.localRotation.eulerAngles.y + 0.03f,
        //    this.transform.localRotation.eulerAngles.z);
        if (isBeingGazed)
        {
            gazeTime += Time.deltaTime;
        }
        if (gazeTime >= clickGazeThreshold)
        {
            TriggerGazeClickEvent();
            //gazeTime = 0f;
        }
    }

    public void TriggerGazeClickEvent()
    {
        if (isTriggered) return;
        isTriggered = true;
        gazeClickEvent.Invoke();
    }
}