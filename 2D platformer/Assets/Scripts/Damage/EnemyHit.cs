using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private int _damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Character>(out Character character))
        {
            if(character.CharacterHit.IsOnHead == false)
            character.Damage(_damage);
        }
    }
}
