using System;
using UnityEngine;

public class DragWithMouse : MonoBehaviour
{
    public Transform originalParent;
    public bool moveParent = false;
    public bool isDragging = false;

    [Header("Gaze interaction")]
    public bool isFocused = false;

    private Vector3 beginPos;
    public Vector3 oldPos;

    public bool limitRange = false;
    public Vector3 limitRangeMin, limitRangeMax;

    [Header("Constrains")]
    public bool constrainX;
    public bool constrainY, constrainZ;


    private void Awake()
    {
        originalParent = transform.parent;
    }

    public void Select() { isFocused = true; }
    public void Unselect() { isFocused = false; }

    public void ResetPosition()
    {
        StopDragging();
        this.transform.position = this.beginPos;
    }

    public void ToggleDragMode()
    {
        isDragging = !isDragging;
        if (isDragging) StartDragging();
        else StopDragging();
    }

    public void StartDragging()
    {
        if (!moveParent)
            this.transform.parent = Camera.main.transform;
        else this.transform.parent.parent = Camera.main.transform;
        oldPos = this.transform.position;
        beginPos = this.transform.position;

        //StopActionCube.Instance.transform.position = new Vector3(
        //    this.transform.position.x,
        //    this.transform.position.y + 0.5f,
        //    this.transform.position.z);
    }

    public void DragObject()
    {
        if (!isDragging) return;
        Vector3 newPos = this.transform.position;
        newPos = CheckLimit(newPos);
        newPos = CheckConstrains(newPos);

        this.transform.position = newPos;
    }

    private Vector3 CheckConstrains(Vector3 newPos)
    {
        if (constrainX) newPos.x = oldPos.x;
        if (constrainY) newPos.y = oldPos.y;
        if (constrainZ) newPos.z = oldPos.z;
        return newPos;
    }

    Vector3 CheckLimit(Vector3 newPos)
    {
        if (limitRange)
        {
            if (this.transform.position.x < limitRangeMin.x)
                newPos.x = limitRangeMin.x;
            else if (this.transform.position.x > limitRangeMax.x)
                newPos.x = limitRangeMax.x;

            if (this.transform.position.y < limitRangeMin.y)
                newPos.y = limitRangeMin.y;
            else if (this.transform.position.y > limitRangeMax.y)
                newPos.y = limitRangeMax.y;

            if (this.transform.position.z < limitRangeMin.z)
                newPos.z = limitRangeMin.z;
            else if (this.transform.position.z > limitRangeMax.z)
                newPos.z = limitRangeMax.z;
        }
        return newPos;
    }

    public void StopDragging()
    {
        if (!moveParent)
            this.transform.parent = this.originalParent.transform;
        else this.transform.parent.parent = this.originalParent.transform;
    }
}
