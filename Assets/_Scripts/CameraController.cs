using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        switch (Input.deviceOrientation)
        {
            //Portrait
            case DeviceOrientation.Portrait:
                transform.rotation = new Quaternion(0, 0, 0, 0);
                break;
            //Landscape
            default:
                transform.rotation = new Quaternion(0, 0, 90, 0);
                break;
        }
    }
}