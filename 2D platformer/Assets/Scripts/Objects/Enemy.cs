using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(AnimationEnemy))]
[RequireComponent(typeof(EnemyHit))]
[RequireComponent(typeof(HealthCharacterAndEnemy))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;

    private int _index;
    private EnemyMover _enemyMover;
    private GroundDetector _groundDetector;
    private AnimationEnemy _animationEnemy;
    private CharacterDetector _characterDetector;
    private HealthCharacterAndEnemy _healthEnemy;

    public void Damage(int damage) => _healthEnemy.TakeDamage(damage);

    private void Awake()
    {
        _healthEnemy = GetComponent<HealthCharacterAndEnemy>();
        _characterDetector = GetComponent<CharacterDetector>();
        _animationEnemy = GetComponent<AnimationEnemy>();
        _groundDetector = GetComponent<GroundDetector>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void FixedUpdate()
    {
        if (_characterDetector.Detector() != null)
        {
            Collider2D collider = _characterDetector.Detector();
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
