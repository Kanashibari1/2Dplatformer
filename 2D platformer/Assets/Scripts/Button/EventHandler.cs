using UnityEngine;
using UnityEngine.UI;

public abstract class EventHandler : MonoBehaviour
{
    [SerializeField] protected Health _health;

    protected Button _button;

    protected void Awake()
    {
        _button = GetComponent<Button>();
    }

    protected void OnEnable()
    {
        _button.onClick.AddListener(DamageOrHeal);
    }

    protected void OnDisable()
    {
        _button.onClick.RemoveListener(DamageOrHeal);
    }

    protected abstract void DamageOrHeal();
}
