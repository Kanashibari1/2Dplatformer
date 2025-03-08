using UnityEngine;
using UnityEngine.UI;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health _health;

    protected Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.ValueChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= UpdateHealth;
    }

    protected abstract void UpdateHealth(float currentValue);
}
