using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSmoothBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;
    private float _smoothSpeed = 0.3f;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += StartHealthUpdate;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= StartHealthUpdate;
        StopCoroutine(UpdateHealth());
    }

    private void StartHealthUpdate()
    {
        StartCoroutine(UpdateHealth());
    }

    private IEnumerator UpdateHealth()
    {
        float targetValue = _health.CurrentHealth / (float)_health.MaxHealth;

        while (Mathf.Approximately(_slider.value, targetValue) != true)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _smoothSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
