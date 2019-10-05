using UnityEngine;

public class RotateInput : MonoBehaviour
{
    private int maxDegrees = 15;
    private float maxMoveSpeed = 0.7f;
    private float verticalPos;
    private float horizontalPos;
    Board boardInputs;

    private void Awake() => boardInputs = new Board();
    private void OnEnable() => boardInputs.Enable();
    private void OnDisable() => boardInputs.Disable();
    private void Update() => Move(boardInputs.Player.Move.ReadValue<Vector2>().x, boardInputs.Player.Move.ReadValue<Vector2>().y);

    public void Move(float x, float y)
    {
        horizontalPos = Mathf.Clamp(horizontalPos + Mathf.Clamp(x, -maxMoveSpeed, maxMoveSpeed), -maxDegrees, maxDegrees);
        verticalPos = Mathf.Clamp(verticalPos + Mathf.Clamp(y, -maxMoveSpeed, maxMoveSpeed), -maxDegrees, maxDegrees);

        transform.eulerAngles = new Vector3(verticalPos, 0, -horizontalPos);
    }
}