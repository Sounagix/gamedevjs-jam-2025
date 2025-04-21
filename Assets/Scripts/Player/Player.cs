using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce;

    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private float _maxSpeed;

    [SerializeField]
    private EchoesManager _echoesManager;

    private Life _life;

    //Sin serializeField

    private Rigidbody2D _rigidbody2D;

    private bool _isGrounded = true;

    private bool _isHoldingBostKey = false;

    private Vector2 _dir;

    private PlayerSounds _playerSounds;

    private void OnEnable()
    {
        PlayerActions.OnPlayerMovementBoost += HandleBost;
        PlayerActions.PlayerJumping += PlayerJumping;
        PlayerActions.OnPlayerJump += HandleJump;
        PlayerActions.OnPlayerMoveLeft += HandleLeftMove;
        PlayerActions.OnPlayerMoveRight += HandleRightMove;
    }


    private void OnDisable()
    {
        PlayerActions.OnPlayerMovementBoost -= HandleBost;
        PlayerActions.OnPlayerJump -= HandleJump;
        PlayerActions.OnPlayerMoveLeft -= HandleLeftMove;
        PlayerActions.OnPlayerMoveRight -= HandleRightMove;
        PlayerActions.PlayerJumping -= PlayerJumping;

    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _life = GetComponent<Life>();
        _playerSounds = GetComponent<PlayerSounds>();
    }

    private void Start()
    {
        gameObject.tag = PlayerActions.PlayerTag;
    }

    private void HandleBost()
    {
        _isHoldingBostKey = !_isHoldingBostKey;
    }
    private void HandleLeftMove()
    {
        if (!_isHoldingBostKey && Math.Abs(_rigidbody2D.velocity.x) < _maxSpeed)
        {
            _rigidbody2D.AddForce(Vector2.left * _moveSpeed, ForceMode2D.Force);
            _dir = Vector2.left;
        }
    }

    private void PlayerJumping()
    {
        _isGrounded = false;
    }

    private void HandleRightMove()
    {
        if (!_isHoldingBostKey && Math.Abs(_rigidbody2D.velocity.x) < _maxSpeed)
        {
            _rigidbody2D.AddForce(Vector2.right * _moveSpeed, ForceMode2D.Force);
            _dir = Vector2.right;
        }
    }

    private void HandleJump()
    {
        if (!_isHoldingBostKey && _isGrounded)
        {
            _isGrounded = false;
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            PlayerActions.OnPlayerJump?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.GroundTag))
        {
            _isGrounded = true;
            PlayerActions.OnPlayerGrouded?.Invoke();
        }
    }

    public Vector2 GetDir()
    {
        return _dir;
    }

    public void TakeDamage(float dmg)
    {
        _playerSounds.PlaySound(PLAYER_SOUNDS.HURT);
        if (_life.TakeDamage(dmg))
        {
            Die();
        }
    }

    public void Die()
    {
        Echoes lastEcho = _echoesManager.GetLastEcho();
        if (lastEcho)
        {
            _playerSounds.PlaySound(PLAYER_SOUNDS.SPAWN);
            transform.position = lastEcho.transform.position;
            _life.ResetLife();
            NexusEnergy.instance.DrainEnergy();
            EchoesActions.OnEchoDie?.Invoke(lastEcho);
            Destroy(lastEcho.gameObject);
        }
        else
        {
            _playerSounds.PlaySound(PLAYER_SOUNDS.SPAWN);
            // Add time for animation and sound
            GameManager.Instance.LoadScene(SCENE.GAME_OVER);
        }
    }
}
