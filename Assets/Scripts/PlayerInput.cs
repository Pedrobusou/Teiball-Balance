using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Range(0, 300)]
    public float rotationSpeed;

    void Update()
    {
        //Keyboard
        if (Input.anyKey) Move(Input.inputString);

        //Joystick
        transform.Rotate(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
    }

    void Move(string key)
    {
        switch (key)
        {
            case "a": transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0); break;
            case "w": transform.Rotate(0, rotationSpeed * Time.deltaTime, 0); break;
            case "s": transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0); break;
            case "d": transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0); break;
        }
    }
}