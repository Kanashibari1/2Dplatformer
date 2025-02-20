using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(CharacterMover))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(AnimationJump))]
[RequireComponent(typeof(AnimationRun))]
public class Character : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private CharacterMover _mover;
    private AnimationRun _animationRun;
    private AnimationJump _animationJump;

    private void Awake()
    {
        _animationJump = GetComponent<AnimationJump>();
        _animationRun = GetComponent<AnimationRun>();
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<CharacterMover>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    private void FixedUpdate()
    {
        if (_inputReader != null)
        {
            _animationRun.Run(_inputReader.Direction);
            _mover.Move(_inputReader.Direction);
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _animationJump.Jump();
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
}
