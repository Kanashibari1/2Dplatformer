using UnityEngine;

public class CharacterDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;

    private int _radius = 5;

    public Collider2D Detector()
    {
        Collider2D found = Physics2D.OverlapCircle(transform.position, _radius, _mask);

        return found;
    }
}
