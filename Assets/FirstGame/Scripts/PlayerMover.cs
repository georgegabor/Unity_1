using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    float speed = 10;

    [SerializeField]
    float angularSpeed = 180;

    [SerializeField]
    Animator animator;

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

        transform.position += velocity * Time.deltaTime * speed;

        bool isRunning = velocity != Vector3.zero;
        animator.SetBool("isRunning", isRunning);

        if (isRunning)
        {
            Quaternion targetRot = Quaternion.LookRotation(velocity);
            transform.rotation =
                Quaternion
                    .RotateTowards(transform.rotation,
                    targetRot,
                    angularSpeed * Time.deltaTime);
        }
    }
}
