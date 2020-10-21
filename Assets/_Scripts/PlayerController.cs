//HEADER: Player Controller, Jake Treleaven, 101186632, 21-10-2020
//Controls the player characters movement and firing
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Configuration;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;

    [Header("Boundary Check")]
    public float horizontalBoundary;

    [Header("Player Speed")]
    public float horizontalSpeed;
    public float maxSpeed;
    public float horizontalTValue;

    [Header("Bullet Firing")]
    public float fireDelay;

    // Private variables
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;

    // Start is called before the first frame update
    void Start()
    {
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        _FireBullet();
    }

     private void _FireBullet()
    {
        // delay bullet firing 
        if(Time.frameCount % 60 == 0 && bulletManager.HasBullets())
        {
            bulletManager.GetBullet(transform.position);
        }
    }

    private void _Move()
    {
        float direction = 0.0f;

        // keyboard support
        if (Input.GetAxis("Horizontal") >= 0.1f)
        {
            // direction is positive
            direction = 1.0f;
        }

        if (Input.GetAxis("Horizontal") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            //Orientation Check
            switch (Input.deviceOrientation)
            {
                //Up Down
                case DeviceOrientation.LandscapeLeft:
                    if (worldTouch.y < transform.position.y)
                    {
                        // direction is negative
                        direction = -1.0f;
                    }

                    if (worldTouch.y > transform.position.y)
                    {
                        // direction is positive
                        direction = 1.0f;
                    }
                    break;
                case DeviceOrientation.LandscapeRight:
                    if (worldTouch.y < transform.position.y)
                    {
                        // direction is positive
                        direction = 1.0f;
                    }

                    if (worldTouch.y > transform.position.y)
                    {
                        // direction is negative
                        direction = -1.0f;
                    }
                    break;
                //Left Right
                default:
                    if (worldTouch.x > transform.position.x)
                    {
                        // direction is positive
                        direction = 1.0f;
                    }

                    if (worldTouch.x < transform.position.x)
                    {
                        // direction is negative
                        direction = -1.0f;
                    }
                    break;
            }
            m_touchesEnded = worldTouch;

        }

        if (m_touchesEnded.x != 0.0f)
        {
           transform.localPosition = new Vector2(Mathf.Lerp(transform.localPosition.x, m_touchesEnded.x, horizontalTValue), transform.localPosition.y);
        }
        else
        {
            switch (Input.deviceOrientation)
            {
                case DeviceOrientation.LandscapeLeft:
                case DeviceOrientation.LandscapeRight:
                    Vector2 newVelocityY = m_rigidBody.velocity + new Vector2(0.0f, direction * horizontalSpeed);
                    m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocityY, maxSpeed);
                    m_rigidBody.velocity *= 0.99f;
                    break;
                default:
                    Vector2 newVelocityX = m_rigidBody.velocity + new Vector2(direction * horizontalSpeed, 0.0f);
                    m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocityX, maxSpeed);
                    m_rigidBody.velocity *= 0.99f;
                    break;
            }
        }
    }

    private void _CheckBounds()
    {
        // check right bounds
        if (transform.localPosition.x >= horizontalBoundary)
        {
            transform.localPosition = new Vector3(horizontalBoundary, transform.localPosition.y, 0.0f);
        }

        // check left bounds
        if (transform.localPosition.x <= -horizontalBoundary)
        {
            transform.localPosition = new Vector3(-horizontalBoundary, transform.localPosition.y, 0.0f);
        }

    }
}
