using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(GroundDetector))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;

    private int _index;
    private EnemyMover _enemyMover;
    private GroundDetector _groundDetector;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _groundDetector = GetComponent<GroundDetector>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void FixedUpdate()
    {
        _enemyMover.Move(_wayPoints[_index], _index);

        if (_enemyMover.HasReachedTarget(_wayPoints[_index]))
        {
            ChooseNextPoint();
        }

        if (_groundDetector.IsGround)
        {
            _animator.SetTrigger("Jump");
            _enemyMover.Jump();
        }
    }

    private void ChooseNextPoint()
    {
        _index = ++_index % _wayPoints.Length;
    }
}
