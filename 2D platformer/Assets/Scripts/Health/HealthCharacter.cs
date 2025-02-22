using UnityEngine;

public class HealthCharacter : MonoBehaviour
{
    private int _currentHealth;
    private int _maxHealth = 100;

    private void Awake()
    {
        _currentHealth = _maxHealth;
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

    public void Health(int health)
    {
        if(_currentHealth + health > _maxHealth) 
            return;

        _currentHealth += health;
    }
}
