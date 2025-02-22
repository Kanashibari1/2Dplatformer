using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Quaternion _rotation;

    private void Awake()
    {
        _rotation = transform.rotation;
    }

    public void Rotation(float direction)
    {
        if (direction > 0)
        {
            _rotation.y = 0;
            transform.rotation = _rotation;
        }

        if (direction < 0)
        {
            _rotation.y = 180;
            transform.rotation = _rotation;
        }
    }
}
