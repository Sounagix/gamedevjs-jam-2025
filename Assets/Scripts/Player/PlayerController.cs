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

    [SerializeField]
    private KeyCode _bostKey;

    [SerializeField]
    private KeyCode _echoKey;

    [SerializeField]
    private KeyCode _nexusShoot;

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

        if (Input.GetKeyDown(_bostKey))
        {
            PlayerActions.OnPlayerMovementBoost?.Invoke();
        }
        else if (Input.GetKeyUp(_bostKey))
        {
            PlayerActions.OnPlayerMovementBoost?.Invoke();
        }

        if (Input.GetKeyDown(_echoKey))
        {
            EchoesActions.OnCreateEcho?.Invoke(transform.position);
        }

        if (Input.GetKeyDown(_nexusShoot))
        {
            PlayerActions.OnPlayerShoot?.Invoke();
        }
    }
}
