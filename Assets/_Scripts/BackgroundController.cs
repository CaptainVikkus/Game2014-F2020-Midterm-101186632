using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Reset()
    {
        transform.localPosition = new Vector3(0.0f, verticalBoundary);
    }

    private void _Move()
    {
        transform.localPosition -= new Vector3(0.0f, verticalSpeed) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        // if the background is lower than the bottom of the screen then reset
        if (transform.localPosition.y <= -verticalBoundary)
        {
            _Reset();
        }
    }
}
