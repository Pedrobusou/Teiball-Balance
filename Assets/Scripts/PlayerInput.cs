using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Range(0, 300)]
    public float rotationSpeed;

    private int maxDegrees = 15;
    private int errorMargin = 5;
    private float verticalMove;
    private float horizontalMove;
    private float verticalPos;
    private float horizontalPos;

    void Update()
    {
        verticalMove = Input.GetAxis("Vertical");
        horizontalMove = Input.GetAxis("Horizontal");

        if (verticalMove != 0 || horizontalMove != 0) Move();
    }

    void Move()
    {
        if (verticalMove > 0 && Mathf.FloorToInt(transform.eulerAngles.x) >= maxDegrees && Mathf.FloorToInt(transform.eulerAngles.x) < maxDegrees + errorMargin)
        {
            verticalMove = 0;
            transform.eulerAngles = new Vector3(maxDegrees, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        if (horizontalMove < 0 && Mathf.FloorToInt(transform.eulerAngles.z) >= maxDegrees && Mathf.FloorToInt(transform.eulerAngles.z) < maxDegrees + errorMargin)
        {
            horizontalMove = 0;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, maxDegrees);
        }

        if (verticalMove < 0 && Mathf.FloorToInt(transform.eulerAngles.x) <= 360 - maxDegrees && Mathf.FloorToInt(transform.eulerAngles.x) > 360 - maxDegrees - errorMargin)
        {
            verticalMove = 0;
            transform.eulerAngles = new Vector3(360 - maxDegrees, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        if (horizontalMove > 0 && Mathf.FloorToInt(transform.eulerAngles.z) <= 360 - maxDegrees && Mathf.FloorToInt(transform.eulerAngles.z) > 360 - maxDegrees - errorMargin)
        {
            horizontalMove = 0;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 360 - maxDegrees);
        }

        horizontalPos += horizontalMove;
        verticalPos += verticalMove;

        transform.eulerAngles = new Vector3(verticalPos, 0, -horizontalPos);
    }
}