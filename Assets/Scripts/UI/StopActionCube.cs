using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopActionCube : MonoBehaviour
{
    public static StopActionCube Instance;

    public float time = 0f;
    public float thresholdTime = 2f;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("OH NO! There's two Stop box!");
        Instance = this;
    }

    public void StayCollided(Collider other)
    {
        time += Time.deltaTime;
        if (time > thresholdTime) StopCurrentAction(other.gameObject);
    }

    public void StopCurrentAction(GameObject gameObject)
    {
        DragWithMouse dragWithMouseComp = gameObject.GetComponent<DragWithMouse>();
        if (dragWithMouseComp) dragWithMouseComp.ResetPosition();
    }

    public void OnTriggerStay(Collider other)
    {
        StayCollided(other);
    }

    public void OnTriggerExit(Collider other)
    {
        time = 0f;
    }
}
