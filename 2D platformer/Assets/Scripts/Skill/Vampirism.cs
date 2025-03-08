using UnityEngine;

public class Vampirism : MonoBehaviour
{
    private Health _health;
    private float _vampirism = 0.1f;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void RestoreHealth()
    {
        _health.Heal(_vampirism);
    }
}
