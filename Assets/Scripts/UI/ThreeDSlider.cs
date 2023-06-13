using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatUnityEvent: UnityEvent<float> { }

public class ThreeDSlider : MonoBehaviour
{
    public float value;

    public float maxValue = 1;

    public ThreeDSliderKnuckle knuckle;
    
    public FloatUnityEvent onValueChangedEvent;

    private void Awake()
    {
        onValueChangedEvent = new FloatUnityEvent();
    }


    public void ResetSlider()
    {
        UpdateValue(0);        //reset
    }


    public void UpdateValue(float value)
    {
        this.knuckle.UpdateValue(value);
    }

    public void ChangeValue(float value)
    { 
        onValueChangedEvent.Invoke(value); 
    }
}
