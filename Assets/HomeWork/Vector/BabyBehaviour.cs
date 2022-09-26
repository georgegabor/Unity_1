using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBehaviour : MonoBehaviour
{
    // [Header("My Variables")]
    // public Vector3 rotationPerSecond;
    [SerializeField]
    float speed = 10;

    [SerializeField]
    float angularSpeed = 180;

    // void Update()
    // {
    //     transform.Rotate(rotationPerSecond * Time.deltaTime);
    // }
    // Update is called once per frame
    void Update()
    {
        // Get directions
        Vector3 velocity = KeyboardInputsHandler();

        // Objects x must be -90 to stand straight up
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(270, eulerRotation.y, 0);

        // transform.eulerAngles =
        //     new Vector3(transform.eulerAngles.x - 90,
        //         transform.eulerAngles.y,
        //         transform.eulerAngles.z);
        transform.position += velocity * Time.deltaTime * speed;

        var step = angularSpeed * Time.deltaTime;

        if (velocity != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(velocity);

            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, targetRot, step);
        }
    }

    Vector3 KeyboardInputsHandler()
    {
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);

        float x = 0;
        float y = 0;

        if (right) x += 1;
        if (left) x += -1;
        if (up) y += 1;
        if (down) y += -1;

        Vector3 velocity = new Vector3(x, 0, y);
        velocity.Normalize();
        return velocity;
    }
}
