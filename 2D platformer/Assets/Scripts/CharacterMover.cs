using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Rotator))]
[RequireComponent(typeof(Jumped))]
public class CharacterMover : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Rotator _rotator;
    private Jumped _jumped;
    private float _speed = 500f;

    private void Awake()
    {
        _jumped = GetComponent<Jumped>();
        _rotator = GetComponent<Rotator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        _rigidbody2D.velocity = new Vector2(direction * _speed * Time.fixedDeltaTime, _rigidbody2D.velocity.y);

        _rotator.RotationCharacter(direction);
    }

    public void Jump()
    {
        _jumped.Jump();
    }
}
