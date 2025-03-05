using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthText : MonoBehaviour
{
    [SerializeField] private Health _health;

    private TextMeshProUGUI _healthText;

    private void Awake()
    {
        _healthText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateHealth;
    }

    private void Start()
    {
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        _healthText.text = $"{_health.CurrentHealth}/{_health.MaxHealth}";
    }
}
