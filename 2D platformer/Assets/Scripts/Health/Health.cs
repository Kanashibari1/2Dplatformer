using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<float> ValueChanged;

    public float MaxValue { get; private set; } = 100;

    public float CurrentValue { get; private set; }

    private void Awake()
    {
        CurrentValue = MaxValue;
    }

    public void TakeDamage(float damage)
    {
        CurrentValue -= damage;

        if (CurrentValue <= 0)
        {
            Die();
        }
        ValueChanged?.Invoke(CurrentValue);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void Heal(float heal)
    {
        float currentHealth = CurrentValue + heal;

        if(currentHealth > MaxValue) 
            return;

        CurrentValue += heal;
        ValueChanged?.Invoke(CurrentValue);
    }
}
