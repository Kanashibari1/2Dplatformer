using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(AnimationJump))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;

    private int _index;
    private EnemyMover _enemyMover;
    private GroundDetector _groundDetector;
    private AnimationJump _animationJump;

    private void Awake()
    {
        _animationJump = GetComponent<AnimationJump>();
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
            _animationJump.Jump();
            _enemyMover.Jump();
        }
    }

    private void ChooseNextPoint()
    {
        _index = ++_index % _wayPoints.Length;
    }
}
