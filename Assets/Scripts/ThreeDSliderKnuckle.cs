using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDSliderKnuckle : MonoBehaviour
{
    public ThreeDSlider slider;
    //private DragWithMouse dragWithMouseComp;
    private DragWithMath dragWithMathComp;

    public bool reverse = false;        // reverse the direction of value

    [Header("Markers and Range")]
    public Transform startMarker;
    public Transform endMarker;
    public float range = 0.09f; // from -range to range

    private void Awake()
    {
        range = (endMarker.transform.position.x - startMarker.transform.position.x);
        dragWithMathComp = GetComponent<DragWithMath>();
    }

    private void Start()
    {
        //dragWithMouseComp.limitRange = true;
        //dragWithMouseComp.limitRangeMin = new Vector3(startMarker.position.x, -9999999, -9999999);
        //dragWithMouseComp.limitRangeMax = new Vector3(endMarker.position.x, 9999999, 9999999);
    }
    public void UpdateValue(float value)
    {
        this.transform.position = new Vector3(
            startMarker.position.x + ((value / slider.maxValue) * range),
            this.transform.position.y,
            this.transform.position.z);
    }

    public void ChangeValue()
    {
        //Debug.Log(this.knuckle.transform.position.x);
        if (!dragWithMathComp.isDragging) return;
        float value = ((this.transform.position.x - startMarker.position.x) / range) * slider.maxValue;
        if (reverse) value = slider.maxValue - value;
        slider.ChangeValue(value);
    }
}
