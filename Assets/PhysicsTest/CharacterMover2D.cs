using UnityEngine;

public class CharacterMover2D : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] float jumpForce = 5;
    [SerializeField] float moveForce = 5;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] int airJumps = 3;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask canJumpLayer;

    bool isOnGround = false;
    int jumpCounts = 0;

    private void OnValidate()
    {
        if (rigidbody == null) rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool isJump = Input.GetKeyDown(KeyCode.Space);

        if (isJump && (isOnGround || jumpCounts > 0))
        {
            Vector2 v = rigidbody.velocity;
            v.y = 0;
            rigidbody.velocity = v;
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse
                );
            jumpCounts--;
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");

        if (isOnGround)
        {
            Vector2 v = rigidbody.velocity;
            v.x = x * moveSpeed;
            rigidbody.velocity = v;
        }
        else
        {
            rigidbody.AddForce(Vector2.right * x * moveForce);

            Vector2 v = rigidbody.velocity;
            float direction = Mathf.Sign(v.x);
            float horizontalSpeed = Mathf.Abs(v.x);
            v.x = Mathf.Min(horizontalSpeed, moveSpeed) * direction;
            rigidbody.velocity = v;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int layer = collision.gameObject.layer;

        if (groundLayer.value != 0 && layer != 0)
        {
            isOnGround = true;

            if (canJumpLayer.value != 0 & layer != 0)
            {
                jumpCounts = airJumps + 1;
            }
            else
                jumpCounts = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }
}
