using UnityEngine;

public class Heart : MonoBehaviour
{
    public int RestoreHealth { get; private set; } = 20;

    public void Break()
    {
        Destroy(gameObject);
    }
}
