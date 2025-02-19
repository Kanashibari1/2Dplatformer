using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(CharacterMover))]
[RequireComponent(typeof(GroundDetector))]
public class Character : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private CharacterMover _mover;
    private Animator _animator;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<CharacterMover>();
        _groundDetector = GetComponent<GroundDetector>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (_inputReader != null)
        {
            if (_inputReader.Direction == 0)
            {
                _animator.SetBool("Run", false);
            }
            else
            {
                _animator.SetBool("Run", true);
                _mover.Move(_inputReader.Direction);
            }
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _animator.SetTrigger("Jump");
            _mover.Jump();
        }
    }
}
