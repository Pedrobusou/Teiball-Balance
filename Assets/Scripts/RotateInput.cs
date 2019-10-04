using UnityEngine;
using UnityEngine.InputSystem;

public class RotateInput : MonoBehaviour
{
    private int maxDegrees = 15;
    private int errorMargin = 5;
    private float verticalMove;
    private float horizontalMove;
    private float verticalPos;
    private float horizontalPos;

    public void OnMove(InputAction.CallbackContext ctx)
    {
        verticalMove = ctx.ReadValue<Vector2>().y;
        horizontalMove = ctx.ReadValue<Vector2>().x;

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