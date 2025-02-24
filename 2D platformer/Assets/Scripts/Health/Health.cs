using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth == 0)
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

        CurrentHealth += health;
    }
}
