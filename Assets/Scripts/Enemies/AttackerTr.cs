using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerTr: FourDirPatroller
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
        if (_attackCoroutine == null && _enemy)
        {
            _state = STATE.ATTACK;
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
        if (_enemy == null && !_state.Equals(STATE.PATROLING))
        {
            StartPatrolling();
        }
        else if (_enemy && _state.Equals(STATE.ATTACK))
        {
            if (_enemy && _attackCoroutine == null && OnRangeAttack())
            {
                _attackCoroutine = StartCoroutine(AttackCoroutine());
            }
            else
            {
                _state = STATE.MOVE;
            }
        }
        else
        {
            base.LateUpdate();
        }
    }

    public override void TakeDamage(int damage, GameObject enemy)
    {
        base.TakeDamage(damage, enemy);
        if (enemy)
        {
            SetEnemy(enemy);
            if (OnRangeAttack())
            {
                Attack();
            }
            else
            {
                _state = STATE.MOVE;
            }
        }
        else
        {
            _state = STATE.PATROLING;
        }
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
            StartPatrolling();
        }
    }
}
