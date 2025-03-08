using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;

    [SerializeField] private int _radius;

    public Collider2D Detect()
    {
        Collider2D found = Physics2D.OverlapCircle(transform.position, _radius, _mask);

        return found;
    }
}
