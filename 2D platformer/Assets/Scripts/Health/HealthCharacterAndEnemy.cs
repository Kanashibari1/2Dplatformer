using UnityEngine;

public class HealthCharacterAndEnemy : MonoBehaviour
{
    public int _currentHealth { get; private set; }
    [SerializeField] private int _maxHealth;

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

    public void Heal(int health)
    {
        if(health > _maxHealth) 
            return;

        _currentHealth += health;
    }
}
