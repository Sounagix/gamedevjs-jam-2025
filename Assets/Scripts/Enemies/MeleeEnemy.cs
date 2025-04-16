using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeleeEnemy : MovableEnemy
{
    [SerializeField]
    private float _attackRange;

    [SerializeField]
    private float _attackDamage;

    [SerializeField]
    private float _attackCooldown;

    [SerializeField]
    protected float _lureDistance;

    private GameObject _enemy;

    private Coroutine _attackCoroutine;

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

    private IEnumerator AttackCoroutine()
    {
        _enemy.GetComponent<Life>().TakeDamage((int)_attackDamage);
        yield return new WaitForSeconds(_attackCooldown);
        _attackCoroutine = null;
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
    }
}
