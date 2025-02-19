using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    private const float Threshold = 1f;

    private float _speed = 2f;
    private Rigidbody2D _rigidbody2D;
    private float _jumpForce = 10f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(Transform position, int index)
    {
        transform.position = Vector2.MoveTowards(transform.position, position.position, _speed * Time.fixedDeltaTime);

        if(index == 0)
        {
            Quaternion rotation = transform.rotation;
            rotation.y = 0;
            transform.rotation = rotation;
        }

        if (index == 1)
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

    public bool HasReachedTarget(Transform position)
    {
        return (position.position - transform.position).sqrMagnitude < Threshold * Threshold;
    }
}
