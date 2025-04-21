using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasite : Enemy
{
    [SerializeField]
    private float _attackRange;

    [SerializeField]
    private int _attackDamage;

    [SerializeField]
    private float _attackCooldown;

    private GameObject _enemy;

    private Coroutine _attackCoroutine;

    private CircleCollider2D _circleCollider2D;

    protected override void Awake()
    {
        base.Awake();
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.radius = _attackRange;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerActions.PlayerTag))
        {
            _enemy = collision.gameObject;
            _state = STATE.ATTACK;
            _attackCoroutine = StartCoroutine(Attack());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerActions.PlayerTag))
        {
            _enemy = null;
            _state = STATE.IDLE;
            if (_attackCoroutine != null)
                StopCoroutine(_attackCoroutine);
        }
    }


    private IEnumerator Attack()
    {
        do
        {
            _enemy.GetComponent<Player>().TakeDamage(_attackDamage);
            yield return new WaitForSeconds(_attackCooldown);
        }
        while (OnRangeAttack());
        _state = STATE.IDLE;
        _attackCoroutine = null;
    }

    private bool OnRangeAttack()
    {
        return _enemy != null && Vector2.Distance(transform.position, _enemy.transform.position) <= _attackRange;
    }
}
