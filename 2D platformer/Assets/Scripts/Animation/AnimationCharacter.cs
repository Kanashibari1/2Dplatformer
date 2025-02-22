using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AnimatorData))]
public class AnimationCharacter : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Run(bool isRun)
    {
        _animator.SetBool(AnimatorData.Params.Run, isRun);
    }

    public void Jump()
    {
        _animator.SetTrigger(AnimatorData.Params.Jump);
    }
}
