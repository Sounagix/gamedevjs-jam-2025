using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : Patroller
{
    [SerializeField]
    protected float _attackRange;

    [SerializeField]
    protected int _attackDamage;

    [SerializeField]
    protected float _attackCooldown;

    protected GameObject _enemy;

    protected Coroutine _attackCoroutine;



    protected override void Awake()
    {
        base.Awake();
        _distanceToStop = _attackRange - 0.1f;
    }

    public void SetEnemy(GameObject enemy)
    {
        _enemy = enemy;
        SetTarget(enemy);
    }

    protected void StopAttacking()
    {
        _enemy = null;
        if (_attackCoroutine != null)
            StopCoroutine(_attackCoroutine);
        _attackCoroutine = null;
    }

    public void Attack()
    {
        if (_attackCoroutine == null)
        {
            _attackCoroutine = StartCoroutine(AttackCoroutine());
        }
    }

    private bool OnRangeAttack()
    {
        return Vector2.Distance(transform.position, _enemy.transform.position) <= _attackRange;
    }

    protected virtual IEnumerator AttackCoroutine()
    {
        yield return null;
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
        if (_enemy != null && _attackCoroutine == null && OnRangeAttack())
        {
            _attackCoroutine = StartCoroutine(AttackCoroutine());
        }
    }

    public override void TakeDamage(int damage, GameObject enemy)
    {
        base.TakeDamage(damage, enemy);
        _enemy = enemy;
        Attack();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerActions.PlayerTag))
        {
            SetEnemy(collision.gameObject);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerActions.PlayerTag))
        {
            StopAttacking();
            StopMoving();
            _state = STATE.PATROLING;
        }
    }
}
