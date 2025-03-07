using System.Collections;
using UnityEngine;

public class HealthSmoothBar : HealthView
{
    private Coroutine _ñoroutine;
    private float _smoothSpeed = 0.3f;
    private int _currentValue;

    protected override void UpdateHealth(int currentValue)
    {
        _currentValue = currentValue;

        if (_ñoroutine == null)
            _ñoroutine = StartCoroutine(SmoothlyUpdate());
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private IEnumerator SmoothlyUpdate()
    {
        float targetValue = _currentValue / (float)_health.MaxValue;

        while (Mathf.Approximately(_slider.value, targetValue) != true)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _smoothSpeed * Time.deltaTime);
            yield return null;
        }

        _ñoroutine = null;
    }
}
