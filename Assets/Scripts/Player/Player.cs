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

    //Sin serializeField

    private Rigidbody2D _rigidbody2D;

    private bool _isGrounded = true;

    private bool _isHoldingBostKey = false;

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
}
