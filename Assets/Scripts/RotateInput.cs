using UnityEngine;
using UnityEngine.InputSystem;

public class RotateInput : MonoBehaviour
{
    private int maxDegrees = 15;
    private float verticalPos;
    private float horizontalPos;

    public void OnMove(InputAction.CallbackContext ctx)
    {
        horizontalPos += ctx.ReadValue<Vector2>().x;
        verticalPos += ctx.ReadValue<Vector2>().y;

        horizontalPos = Mathf.Clamp(horizontalPos, -maxDegrees, maxDegrees);
        verticalPos = Mathf.Clamp(verticalPos, -maxDegrees, maxDegrees);

        transform.eulerAngles = new Vector3(verticalPos, 0, -horizontalPos);
    }
}