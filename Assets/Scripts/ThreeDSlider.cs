using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatUnityEvent: UnityEvent<float> { }

public class ThreeDSlider : MonoBehaviour
{
    public float value;

    public float maxValue = 1;

    public bool reverse = false;

    [Header("Markers and Range")]
    public Transform startMarker;
    public Transform endMarker;
    public float range = 0.09f; // from -range to range

    public GameObject knuckle;
    public DragWithMouse dragWithMouseComp;

    public FloatUnityEvent onValueChangedEvent;

    private void Awake()
    {
        onValueChangedEvent = new FloatUnityEvent();
        range = (endMarker.transform.position.x - startMarker.transform.position.x);
    }

    private void Start()
    {
        dragWithMouseComp.limitRange = true;
        dragWithMouseComp.limitRangeMin = new Vector3(startMarker.position.x, -9999999, -9999999);
        dragWithMouseComp.limitRangeMax = new Vector3(endMarker.position.x, 9999999, 9999999);
    }

    public void UpdateValue(float value)
    {
        this.knuckle.transform.position = new Vector3(
            startMarker.position.x + ( (value / maxValue) * range ),
            this.knuckle.transform.position.y, 
            this.knuckle.transform.position.z);
    }

    public void ChangeValue()
    {
        //Debug.Log(this.knuckle.transform.position.x);
        this.value = (( this.knuckle.transform.position.x - startMarker.position.x ) / range ) * maxValue;
        if (reverse) this.value = maxValue - this.value;
        ChangeValue(this.value);
    }

    public void ChangeValue(float value)
    { 
        onValueChangedEvent.Invoke(value); 
    }
}
