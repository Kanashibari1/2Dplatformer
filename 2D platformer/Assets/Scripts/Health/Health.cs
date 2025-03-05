using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealth { get; private set; } = 100;

    public int CurrentHealth { get; private set; }

    public event Action HealthChanged;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth == 0)
        {
            Die();
        }
        HealthChanged?.Invoke();
        Debug.Log(CurrentHealth);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void Heal(int heal)
    {
        int currentHealth = CurrentHealth + heal;

        if(currentHealth > MaxHealth) 
            return;

        CurrentHealth += heal;
        Debug.Log(CurrentHealth);
        HealthChanged?.Invoke();
    }
}
