using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    private int _currentHealth;
    private int _health = 10;

    private void Awake()
    {
        _currentHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
