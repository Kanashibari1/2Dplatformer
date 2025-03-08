using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(EnemyAnimator))]
[RequireComponent(typeof(EnemyHit))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;

    private int _index;
    private EnemyMover _enemyMover;
    private GroundDetector _groundDetector;
    private EnemyAnimator _animationEnemy;
    private Detector _characterDetector;
    private Health _health;

    public void Damage(float damage) => _health.TakeDamage(damage);

    private void Awake()
    {
        _health = GetComponent<Health>();
        _characterDetector = GetComponent<Detector>();
        _animationEnemy = GetComponent<EnemyAnimator>();
        _groundDetector = GetComponent<GroundDetector>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void FixedUpdate()
    {
        if (_characterDetector.Detect() != null)
        {
            Collider2D collider = _characterDetector.Detect();
            _enemyMover.Move(collider.transform);
        }
        else
        {
            _enemyMover.Move(_wayPoints[_index]);

            if (_enemyMover.HasReachedTarget(_wayPoints[_index]))
            {
                ChooseNextPoint();
            }
        }

        if (_groundDetector.IsGround)
        {
            _animationEnemy.Jump();
            _enemyMover.Jump();
        }
    }

    private void ChooseNextPoint()
    {
        _index = ++_index % _wayPoints.Length;
    }
}
