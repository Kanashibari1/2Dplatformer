using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform[] _position;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        for (int i = 0; i < _position.Length; i++)
        {
            Instantiate(_prefab, _position[i].position, _position[i].rotation);
        }
    }
}
