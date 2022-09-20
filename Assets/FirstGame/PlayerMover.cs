using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float angularSpeed = 180;

    void Update()
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

        transform.position  += velocity * Time.deltaTime * speed;

        if (velocity != Vector3.zero) { 
            Quaternion targetRot = Quaternion.LookRotation(velocity);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, angularSpeed * Time.deltaTime);
        }
    }
}
