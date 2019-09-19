using UnityEngine;

public class WallRotation : MonoBehaviour
{
    [Range(0, 300)]
    public float speed = 5f;
    public bool clockwise = true;

    private void Start()
    {
        if (!clockwise) speed *= -1;
    }

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
