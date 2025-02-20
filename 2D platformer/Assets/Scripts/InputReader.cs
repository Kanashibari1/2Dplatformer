using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private bool _isJump;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(KeyCode.W))
        {
            _isJump = true;
        }
    }

    public bool GetIsJump()
    {
        bool isJump = _isJump;
        _isJump = false;
        return isJump;
    }
}
