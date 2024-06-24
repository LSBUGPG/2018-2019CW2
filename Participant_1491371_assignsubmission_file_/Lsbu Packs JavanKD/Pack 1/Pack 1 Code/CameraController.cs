using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public float CameraRotation = 100.0f; // Camera Rotation speed is set


    // Use this for initialization
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Mouse Y") * CameraRotation * -1; // This rotates your character's view upwards when moving your mouse forwards and backwards, though the "-1" is so that the movement
        // is not inverted

        rotation *= Time.deltaTime; // This sets how fast it does this action
        transform.Rotate(rotation, 0, 0);
    }
}
