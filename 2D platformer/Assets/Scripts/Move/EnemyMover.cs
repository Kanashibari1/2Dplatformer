using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Rotator))]
[RequireComponent(typeof(Jumper))]
public class EnemyMover : MonoBehaviour
{
    private const float Threshold = 1f;

    private Jumper _jumped;
    private Rigidbody2D _rigidbody2D;
    private Rotator _rotator;
    private float _speed = 50f;

    private void Awake()
    {
        _jumped = GetComponent<Jumper>();
        _rotator = GetComponent<Rotator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(Transform point)
    {
        Vector2 direction = (point.position - transform.position).normalized;
        _rigidbody2D.velocity = new Vector2(direction.x * _speed * Time.fixedDeltaTime, _rigidbody2D.velocity.y);

        _rotator.Rotate(direction.x);
    }

    public void Jump()
    {
        _jumped.Jump();
    }

    public bool HasReachedTarget(Transform position)
    {
        return (position.position - transform.position).sqrMagnitude < Threshold * Threshold;
    }
}
