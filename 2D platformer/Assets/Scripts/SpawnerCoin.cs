using UnityEngine;

public class SpawnerCoin : MonoBehaviour
{
    [SerializeField] private Transform[] _position;
    [SerializeField] private Coin _coinPrefab;

    private void Start()
    {
        Spawner();
    }

    public void Spawner()
    {
        for (int i = 0; i < _position.Length; i++)
        {
            Instantiate(_coinPrefab, _position[i].position, _position[i].rotation);
        }
    }
}
