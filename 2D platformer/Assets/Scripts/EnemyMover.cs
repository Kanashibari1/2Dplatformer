using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Rotator))]
[RequireComponent(typeof(Jumped))]
public class EnemyMover : MonoBehaviour
{
    private const float Threshold = 1f;

    private Jumped _jumped;
    private Rigidbody2D _rigidbody2D;
    private Rotator _rotator;
    private float _speed = 30f;

    private void Awake()
    {
        _jumped = GetComponent<Jumped>();
        _rotator = GetComponent<Rotator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(Transform position, int index)
    {
        Vector2 direction = (position.position - transform.position).normalized;

        _rigidbody2D.velocity = new Vector2(direction.x * _speed * Time.fixedDeltaTime, _rigidbody2D.velocity.y);

        _rotator.RotationEnemy(index);
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
