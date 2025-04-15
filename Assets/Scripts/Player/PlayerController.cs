using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode _jumpKey;

    [SerializeField]
    private KeyCode _moveLeftKey;

    [SerializeField]
    private KeyCode _moveRightKey;

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            PlayerActions.OnPlayerJump?.Invoke();
        }
        if (Input.GetKey(_moveLeftKey))
        {
            PlayerActions.OnPlayerMoveLeft?.Invoke();
        }
        if (Input.GetKey(_moveRightKey))
        {
            PlayerActions.OnPlayerMoveRight?.Invoke();
        }
    }
}
