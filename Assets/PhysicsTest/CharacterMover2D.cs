using UnityEngine;

public class CharacterMover2D : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] float force;

    private void OnValidate()
    {
        if (rigidbody == null) rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool jumpPress = Input.GetKeyDown(KeyCode.Space);

        if (jumpPress)
            rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse
                );
    }
}
