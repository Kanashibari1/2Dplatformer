using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(CharacterMover))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(AnimationCharacter))]
[RequireComponent(typeof(HealthCharacter))]
[RequireComponent(typeof(CharacterHit))]
public class Character : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private CharacterMover _mover;
    private AnimationCharacter _animationCharacter;
    private HealthCharacter _healthCharacter;

    public CharacterHit CharacterHit { get; private set; }

    public void Damage(int damage) => _healthCharacter.TakeDamage(damage);

    private void Awake()
    {
        CharacterHit = GetComponent<CharacterHit>();
        _healthCharacter = GetComponent<HealthCharacter>();
        _animationCharacter = GetComponent<AnimationCharacter>();
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<CharacterMover>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    private void FixedUpdate()
    {
        if (_inputReader != null)
        {
            bool isRun = _inputReader.Direction != 0;
            _animationCharacter.Run(isRun);
            _mover.Move(_inputReader.Direction);
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _animationCharacter.Jump();
            _mover.Jump();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out _))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            _healthCharacter.Health(health.HealthPoint);
            health.BrakeHealth();
        }

    }
}
