using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(DataAnimator))]
public class CharacterAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Run(bool isRun)
    {
        _animator.SetBool(DataAnimator.Params.Run, isRun);
    }

    public void Jump()
    {
        _animator.SetTrigger(DataAnimator.Params.Jump);
    }
}
