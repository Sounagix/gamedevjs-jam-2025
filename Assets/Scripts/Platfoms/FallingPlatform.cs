using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingPlatform : Platform
{
    [SerializeField]
    private float _fallingDelay;

    private Coroutine _fallingCoroutine;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // Set the Rigidbody to be kinematic initially
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.PlayerTag))
        {
            _fallingCoroutine = StartCoroutine(Falling());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.PlayerTag) && _fallingCoroutine != null)
        {
            StopCoroutine(_fallingCoroutine);
        }
    }

    private IEnumerator Falling()
    {
        yield return new WaitForSeconds(_fallingDelay);
        rb.isKinematic = false;
    }
}
