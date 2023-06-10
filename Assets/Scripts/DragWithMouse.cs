using UnityEngine;

public class DragWithMouse : MonoBehaviour
{
    public Transform originalParent;
    public bool moveParent = false;

    private Vector3 oldPos;

    public bool limitRange = false;
    public Vector3 limitRangeMin, limitRangeMax;

    [Header("Constrains")]
    public bool constrainX;
    public bool constrainY, constrainZ;

    private void OnMouseDown()
    {
        if (!moveParent)
            this.transform.parent = Camera.main.transform;
        else this.transform.parent.parent = Camera.main.transform;
        oldPos = this.transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 newPos = this.transform.position;
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

        if (constrainX)
            newPos.x = oldPos.x;
        if (constrainY) newPos.y = oldPos.y;
        if (constrainZ) newPos.z = oldPos.z;

        this.transform.position = newPos;
    }

    private void OnMouseUp()
    {
        if (!moveParent)
            this.transform.parent = this.originalParent.transform;
        else this.transform.parent.parent = this.originalParent.transform;
    }
}
