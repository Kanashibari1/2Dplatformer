using UnityEngine;

public class Health : MonoBehaviour
{
    public int HealthPoint { get; private set; } = 20;

    public void BrakeHealth()
    {
        Destroy(gameObject);
    }
}
