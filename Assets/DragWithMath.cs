using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Use some geometry to calculate the distance needed to move the cube.
public class DragWithMath : MonoBehaviour
{
    public Transform camPoint, startPoint, endPoint;        //denote: C, S, E
    private float edgeCS, edgeCE, edgeSE;          //CS: cam -> startPoint, CE: cam -> endpoint, SE: start->end point
    private float angleC, angleS, angleE;

    private float angleF;

    public bool isDragging = false;
    private Quaternion oldRotation;

    public Transform emptyObj;
    public float bias = 0f;


    private void Awake()
    {
        camPoint = Camera.main.transform;
    }

    private void Start()
    {
        edgeCS = Vector3.Distance(camPoint.position, startPoint.position);
        edgeCE = Vector3.Distance(camPoint.position, endPoint.position);
        edgeSE = Vector3.Distance(startPoint.position, endPoint.position);

        angleC = AngleLawOfCosine(edgeCS, edgeCE, edgeSE);
        angleS = AngleLawOfCosine(edgeCS, edgeSE, edgeCE);
        angleE = AngleLawOfCosine(edgeCE, edgeSE, edgeCS);

        //angleF = AngleLawOfCosine(startPoint.position.z,
        //    Mathf.Sqrt( Mathf.Pow(startPoint.position.z, 2) + Mathf.Pow(startPoint.position.x, 2) ),
        //    startPoint.position.x);
        emptyObj.LookAt(startPoint);
        angleF = emptyObj.rotation.eulerAngles.y;
    }

    private float AngleLawOfCosine(float a, float b, float c)
    {
        float cosC = (Mathf.Pow(a, 2) + Mathf.Pow(b, 2) - Mathf.Pow(c, 2)) / (2 * a * b);
        return Mathf.Acos(cosC) * Mathf.Rad2Deg;
    }

    //imagine there's a point on SE, called M. We need to find x = SM.
    public float moveOffset(float angle)
    {
        float x = edgeCS * Mathf.Sin(Mathf.Deg2Rad * angle) / Mathf.Sin(Mathf.Deg2Rad * (180 - angle - angleS));
        float frac = x / edgeSE;
        return (endPoint.localPosition.x - startPoint.localPosition.x) * frac;
    }

    public void MoveWithAngle(float angle)
    {
        Vector3 newLocalPos = startPoint.localPosition;
        newLocalPos.x = startPoint.localPosition.x + moveOffset(angle);
        this.transform.localPosition = newLocalPos;
    }

    #region dragging

    public void ToggleDragMode()
    {
        isDragging = !isDragging;
        if (isDragging) StartDragging();
        else StopDragging();
    }

    public void StopDragging()
    {
        isDragging = false;
    }

    private void StartDragging()
    {
        //oldRotation = Camera.main.transform.rotation;
    }

    public void DragObject()
    {
        if (!isDragging) return;
        float angle = Camera.main.transform.rotation.eulerAngles.y - angleF + bias;
        //float angle = Camera.main.transform.rotation.eulerAngles.y - oldRotation.eulerAngles.y;
        Debug.Log("Angle for slider: " + angle);
        if (angle < 0)
        {
            bias = 360f;
        }
        else if (angle > 360)
            bias = 0f;
        MoveWithAngle(angle);
    }

    #endregion
}
