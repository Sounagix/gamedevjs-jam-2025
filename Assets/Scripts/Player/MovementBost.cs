using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBost : MonoBehaviour
{
    [SerializeField]
    private float _timeToWaitForBoost;

    [SerializeField]
    private float _boostJumpForce, _boostSlideForce;

    [SerializeField]
    private float _boostSlideEnergyCost, _boostJumpEnergyCost;

    private bool _isHoldingBostKey = false;

    private bool _isGrounded;

    private Rigidbody2D _rigidbody2D;

    private Coroutine _jumpCoroutine;

    private Coroutine _slideLeftCoroutine;

    private Coroutine _slideRightCoroutine;

    private void OnEnable()
    {
        PlayerActions.OnPlayerMovementBoost += HandleBost;
        PlayerActions.OnPlayerJump += HandleBostJump;
        PlayerActions.OnPlayerMoveLeft += HandleLeftBoost;
        PlayerActions.OnPlayerMoveRight += HandleRightBoost;
        PlayerActions.OnPlayerGrouded += OnPlayerGrounded;
        PlayerActions.PlayerJumping += OnPlayerJumping; ;
    }

    private void OnDisable()
    {
        PlayerActions.OnPlayerMovementBoost -= HandleBost;
        PlayerActions.OnPlayerJump -= HandleBostJump;
        PlayerActions.OnPlayerMoveLeft -= HandleLeftBoost;
        PlayerActions.OnPlayerMoveRight -= HandleRightBoost;
        PlayerActions.OnPlayerGrouded -= OnPlayerGrounded;
        PlayerActions.PlayerJumping -= OnPlayerJumping; ;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void OnPlayerGrounded()
    {
        _isGrounded = true;
    }

    private void OnPlayerJumping()
    {
        _isGrounded = false;
    }

    private void HandleBost()
    {
        _isHoldingBostKey = !_isHoldingBostKey;
    }

    public void HandleBostJump()
    {
        if (_isGrounded && _isHoldingBostKey && _jumpCoroutine == null && NexusEnergy.instance.CanUseEnergy(_boostJumpEnergyCost))
        {
            NexusEnergy.instance.UseEnergy(_boostJumpEnergyCost);
            _jumpCoroutine = StartCoroutine(Jump());
        }
    }

    private void HandleLeftBoost()
    {
        if (_isHoldingBostKey && _slideLeftCoroutine == null && NexusEnergy.instance.CanUseEnergy(_boostSlideEnergyCost))
        {
            NexusEnergy.instance.UseEnergy(_boostSlideEnergyCost);
            _slideLeftCoroutine = StartCoroutine(SLideLeft());
        }
    }

    private void HandleRightBoost()
    {
        if (_isHoldingBostKey && _slideRightCoroutine == null && NexusEnergy.instance.CanUseEnergy(_boostSlideEnergyCost))
        {
            NexusEnergy.instance.UseEnergy(_boostSlideEnergyCost);
            _slideRightCoroutine = StartCoroutine(SLideRight());
        }
    }

    private IEnumerator Jump()
    {
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(_timeToWaitForBoost);
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        _isGrounded = false;
        _rigidbody2D.AddForce(Vector2.up * _boostJumpForce, ForceMode2D.Impulse);
        PlayerActions.PlayerJumping?.Invoke();
        _jumpCoroutine = null;
    }

    private IEnumerator SLideLeft()
    {
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(_timeToWaitForBoost);
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        _rigidbody2D.AddForce(Vector2.left * _boostSlideForce, ForceMode2D.Impulse);
        _slideLeftCoroutine = null;
    }

    private IEnumerator SLideRight()
    {
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(_timeToWaitForBoost);
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;   
        _rigidbody2D.AddForce(Vector2.right * _boostSlideForce, ForceMode2D.Impulse);
        _slideRightCoroutine = null;
    }
}
