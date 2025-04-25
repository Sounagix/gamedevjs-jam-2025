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

    private Animator _animator;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", Mathf.Abs(_rb.velocity.x));

        if (_rb.velocity.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_rb.velocity.x > 0)
        {
            _spriteRenderer.flipX = false;
        }

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

        if (Input.GetMouseButtonDown(0))
        {
            PlayerActions.OnPlayerShoot?.Invoke();
        }
    }
}
