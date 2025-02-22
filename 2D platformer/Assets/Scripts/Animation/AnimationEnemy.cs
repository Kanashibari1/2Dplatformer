using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AnimatorData))]
public class AnimationEnemy : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Jump()
    {
        _animator.SetTrigger(AnimatorData.Params.Jump);
    }
}
