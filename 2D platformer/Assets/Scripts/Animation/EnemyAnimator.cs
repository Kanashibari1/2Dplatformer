using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(DataAnimator))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Jump()
    {
        _animator.SetTrigger(DataAnimator.Params.Jump);
    }
}
