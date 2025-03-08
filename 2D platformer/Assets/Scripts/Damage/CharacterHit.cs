using UnityEngine;

public class CharacterHit : MonoBehaviour
{
    private int _damage = 10;
    private float _damageSkill = 0.1f;
    private int _force = 10;
    private Rigidbody2D _rigidbody2D;
    private Detector _detector;
    private Vampirism _vampirism;

    public bool IsOnHead { get; private set; } = false;

    private void Awake()
    {
        _vampirism = GetComponent<Vampirism>();
        _detector = GetComponent<Detector>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Vector2 contact = collision.contacts[0].point;
            Vector2 position = enemy.transform.position;

            if (contact.y > position.y)
            {
                IsOnHead = true;
                enemy.Damage(_damage);
                ApplyKnockback();
            }
            else
            {
                IsOnHead = false;
            }
        }
    }

    public void DamageVampirism()
    {
        Collider2D collider2D = _detector.Detect();

        if (collider2D != null)
        {
            if (collider2D.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.Damage(_damageSkill);
                _vampirism.RestoreHealth();
            }
        }
    }

    private void ApplyKnockback()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
        _rigidbody2D.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
    }
}
