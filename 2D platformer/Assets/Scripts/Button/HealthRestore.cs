using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HealthRestore : EventHandler
{
    private const int _heal = 10;

    protected override void DamageOrHeal()
    {          
        _health.Heal(_heal);
    }
}
