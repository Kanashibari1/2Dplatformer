using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Damage : EventHandler
{
    private int _damage = 10;

    protected override void DamageOrHeal()
    {
        _health.TakeDamage(_damage);
    }
}
