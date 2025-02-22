using UnityEngine;

public class SpawnerHealth : MonoBehaviour
{
    [SerializeField] private Health _healthPrefab;
    [SerializeField] private Transform[] _position;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        for (int i = 0; i < _position.Length; i++)
        {
            Instantiate(_healthPrefab, _position[i].position, _position[i].rotation);
        }
    }
}
