using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMover : MonoBehaviour
{
    private float _speed = 500f;
    private float _jumpForce = 12f;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        _rigidbody2D.velocity = new Vector2(direction * _speed * Time.fixedDeltaTime, _rigidbody2D.velocity.y);

        if(direction > 0)
        {
            Quaternion rotation = transform.rotation;
            rotation.y = 0;
            transform.rotation = rotation;
        }

        if (direction < 0)
        {
            Quaternion rotation = transform.rotation;
            rotation.y = 180;
            transform.rotation = rotation;
        }
    }

    public void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
    }
}
