using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationKeyboardControl : MonoBehaviour
{
    public float speed = 0.2f;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)){
            this.transform.Rotate(speed, 0, 0);
        } else if (Input.GetKey(KeyCode.DownArrow)){
            this.transform.Rotate(-speed, 0, 0);
        } else if (Input.GetKey(KeyCode.LeftArrow)){
            this.transform.Rotate(0, -speed, 0);
        } else if ( Input.GetKey(KeyCode.RightArrow)) { 
            this.transform.Rotate(0, speed, 0); 
        }
    }
}
