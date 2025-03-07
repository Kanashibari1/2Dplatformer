using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxValue { get; private set; } = 100;

    public int CurrentValue { get; private set; }

    public event Action<int> ValueChanged;

    private void Awake()
    {
        CurrentValue = MaxValue;
    }

    public void TakeDamage(int damage)
    {
        CurrentValue -= damage;

        if (CurrentValue == 0)
        {
            Die();
        }
        ValueChanged?.Invoke(CurrentValue);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void Heal(int heal)
    {
        int currentHealth = CurrentValue + heal;

        if(currentHealth > MaxValue) 
            return;

        CurrentValue += heal;
        ValueChanged?.Invoke(CurrentValue);
    }
}
