using UnityEngine;

public class Rotator : MonoBehaviour
{
    public void RotationCharacter(float direction)
    {
        if (direction > 0)
        {
            Quaternion rotation = transform.rotation;
            rotation.y = 0;
            transform.rotation = rotation;
        }

        if (direction < 0)
        {
            Quaternion rotation = transform.rotation;
            rotation.y = 180;
            transform.rotation = rotation;
        }
    }

    public void RotationEnemy(int index)
    {
        if (index == 0)
        {
            Quaternion rotation = transform.rotation;
            rotation.y = 0;
            transform.rotation = rotation;
        }
        else
        {
            Quaternion rotation = transform.rotation;
            rotation.y = 180;
            transform.rotation = rotation;
        }
    }
}
