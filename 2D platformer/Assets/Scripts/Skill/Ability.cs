using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    private const float _durationCoolDown = 4f;

    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Image _image;
    [SerializeField] private Slider _slider;

    private CharacterHit _characterHit;
    private Coroutine _coroutine;
    private int _durationSkill = 6;
    private float _currentCoolDown = 4f;
    private float _remainingTime = 0;

    private bool _isCoolDown = false;
    
    private void Awake()
    {
        _image.gameObject.SetActive(false);
        _characterHit = GetComponent<CharacterHit>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isCoolDown != true)
        {
            _coroutine = StartCoroutine(UseSkill());
        }

        if (_isCoolDown && _coroutine == null)
        {
            _currentCoolDown -= Time.deltaTime;
            _slider.value = 1f - (_currentCoolDown / _durationCoolDown);

            if (_currentCoolDown <= 0f)
            {
                _currentCoolDown = 4f;
                _isCoolDown = false;
            }
        }
    }

    private IEnumerator UseSkill()
    {
        _isCoolDown = true;
        float endTime = Time.time + _durationSkill;

        _image.gameObject.SetActive(true);

        while (endTime > Time.time)
        {
            _remainingTime = endTime - Time.time;
            _slider.value = _remainingTime / _durationSkill;
            _characterHit.DamageVampirism();
            _rectTransform.sizeDelta = new Vector2(10, 10);
            yield return null;
        }

        _image.gameObject.SetActive(false);

        StopCoroutine(UseSkill());
        _coroutine = null;
    }
}
