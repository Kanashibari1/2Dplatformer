using UnityEngine;

public class AnimatorData : MonoBehaviour
{
    public class Params
    {
        public static readonly int Run = Animator.StringToHash(nameof(Run));
        public static readonly int Jump = Animator.StringToHash(nameof(Jump));
    }
}
