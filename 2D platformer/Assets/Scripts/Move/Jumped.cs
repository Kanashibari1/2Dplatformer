using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumped : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _jumpForce = 7f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
    }
}
