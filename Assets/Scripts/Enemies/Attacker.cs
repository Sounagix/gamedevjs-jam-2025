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

    protected List<GameObject> _enemies = new();

    protected Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _distanceToStop = _attackRange - 0.1f;
        _animator = GetComponent<Animator>();
    }

    public void SetEnemy(GameObject enemy)
    {
        _enemy = enemy;
        SetTarget(enemy);
    }

    public override void SetTaunt(GameObject taunter)
    {
        if (_enemy != null && !_enemies.Contains(_enemy))
        {
            _enemies.Add(_enemy);
        }
        SetEnemy(taunter);
        _state = STATE.ATTACK;
        if (_attackCoroutine == null)
            _attackCoroutine = StartCoroutine(AttackCoroutine());
        else
        {
            ResetAttack();
        }
    }

    private void ResetAttack()
    {
        StopCoroutine(_attackCoroutine);
        _attackCoroutine = null;
        _attackCoroutine = StartCoroutine(AttackCoroutine());
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
        if (collision.CompareTag(PlayerActions.PlayerTag) || collision.CompareTag(PlayerActions.EchoTag))
        {
            if (_enemy != null)
            {
                if (!_enemies.Contains(collision.gameObject))
                {
                    _enemies.Add(collision.gameObject);
                }
                _enemy = GetCloserEnemy();
            }
            else
            {
                SetEnemy(collision.gameObject);
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerActions.PlayerTag) || collision.CompareTag(PlayerActions.EchoTag))
        {
            if (_enemies.Contains(collision.gameObject))
            {
                _enemies.Remove(collision.gameObject);
            }

            if (_enemy && _enemy.Equals(collision.gameObject))
            {
                if (_enemy.Equals(collision.gameObject) && _enemies.Count > 0)
                {
                    var newEnemy = GetCloserEnemy();
                    SetEnemy(newEnemy);
                }
                else
                {
                    StopAttacking();
                    StopMoving();
                    StartPatrolling();
                }
            }
        }
    }

    private GameObject GetCloserEnemy()
    {
        GameObject closestEnemy = null;
        float shortestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject enemy in _enemies)
        {
            float distance = Vector3.Distance(currentPosition, enemy.transform.position);
            if (distance < shortestDistance && distance <= _attackRange)
            {
                shortestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}
