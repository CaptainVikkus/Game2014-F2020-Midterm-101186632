//HEADER: Camera Controller, Jake Treleaven, 101186632, 21-10-2020
//Rotates the camera according to device orientation
//INCOMPLETE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float portraitRot;
    public float landscapeRot;

    // Update is called once per frame
    void Update()
    {
        switch (Input.deviceOrientation)
        {
            //Portrait
            case DeviceOrientation.Portrait:
                transform.rotation = new Quaternion(0, 0, portraitRot, 0);
                break;
            //Landscape
            case DeviceOrientation.LandscapeLeft:
                transform.rotation = new Quaternion(0, 0, landscapeRot, 0);
                break;
            case DeviceOrientation.LandscapeRight:
                transform.rotation = new Quaternion(0, 0, -landscapeRot, 0);
                break;
            default:
                transform.rotation = new Quaternion(0, 0, 0, 0);
                break;
        }
    }
}