//HEADER: Orientation Controller, Jake Treleaven, 101186632, 21-10-2020
//Rotates the main rotator object according to device orientation
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrientationController : MonoBehaviour
{
    public float landscapeRot = 90.0f;
    public float landscapeScale = 2.0f;
    private Vector3 m_lScale;
    public float portraitRot = 0.0f;
    public float portraitScale = 0.5f;
    private Vector3 m_pScale;

    public TextMeshProUGUI text;

    void Start()
    {
        m_lScale = new Vector3(landscapeScale, landscapeScale, landscapeScale);
        m_pScale = new Vector3(portraitScale, portraitScale, portraitScale);
    }
    // Update is called once per frame
    void Update()
    {
        switch (Input.deviceOrientation)
        {
            case DeviceOrientation.LandscapeLeft:
                transform.rotation = new Quaternion(0, 0, landscapeRot, 0);
                transform.localScale = m_lScale;
                text.text = "LandscapeLeft";
                break;
            case DeviceOrientation.LandscapeRight:
                transform.rotation = new Quaternion(0, 0, -landscapeRot, 0);
                transform.localScale = m_lScale;
                text.text = "LandscapeRight";
                break;
            case DeviceOrientation.Portrait:
                transform.rotation = new Quaternion(0, 0, portraitRot, 0);
                transform.localScale = m_pScale;
                text.text = "Portrait";
                break;
            default: //other
                text.text = "Unkown";
                break;
        }
    }
}
