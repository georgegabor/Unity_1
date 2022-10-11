using UnityEngine;

public class CharacterMover2D : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] float jumpForce = 5;
    [SerializeField] int airJumps = 3;

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
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse
                );
            jumpCounts--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
        jumpCounts = airJumps + 1;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }
}
