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

    private void OnEnable()
    {
        PlayerActions.OnPlayerJump += HandleJump;
        PlayerActions.OnPlayerMoveLeft += HandleLeftMove;
        PlayerActions.OnPlayerMoveRight += HandleRightMove;
    }

    private void OnDisable()
    {
        PlayerActions.OnPlayerJump -= HandleJump;
        PlayerActions.OnPlayerMoveLeft -= HandleLeftMove;
        PlayerActions.OnPlayerMoveRight -= HandleRightMove;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        gameObject.tag = PlayerActions.PlayerTag;
    }

    private void HandleLeftMove()
    {
        if (Math.Abs(_rigidbody2D.velocity.x) > _maxSpeed) return;
        _rigidbody2D.AddForce(Vector2.left * _moveSpeed, ForceMode2D.Force);
    }

    private void HandleRightMove()
    {
        _rigidbody2D.AddForce(Vector2.right * _moveSpeed, ForceMode2D.Force);
    }

    private void HandleJump()
    {
        if (!_isGrounded) return;
        _isGrounded = false;
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.GroundTag))
        {
            _isGrounded = true;
        }
    }
}
