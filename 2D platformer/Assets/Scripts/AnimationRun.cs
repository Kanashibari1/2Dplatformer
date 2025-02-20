using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AnimatorData))]
public class AnimationRun : MonoBehaviour
{
    bool _run;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Run(float direction)
    {
        if (direction == 0)
        {
            _run = false;
        }
        else
        {
            _run = true;
        }

        _animator.SetBool(AnimatorData.Params.Run, _run);
    }
}
