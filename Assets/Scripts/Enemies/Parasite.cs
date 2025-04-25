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

    private List<GameObject> _enemies = new();

    private Coroutine _attackCoroutine;

    private CircleCollider2D _circleCollider2D;

    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.radius = _attackRange;
        _animator = GetComponent<Animator>();
    }

    public override void SetTaunt(GameObject taunter)
    {
        if (_enemy != null && !_enemies.Contains(_enemy))
        {
            _enemies.Add(_enemy);
        }
        _enemy = taunter;
        _state = STATE.ATTACK;
        if (_attackCoroutine == null)
            _attackCoroutine = StartCoroutine(Attack());
        else
        {
            ResetAttack();
        }
    }

    private void ResetAttack()
    {
        StopCoroutine(_attackCoroutine);
        _attackCoroutine = null;
        _attackCoroutine = StartCoroutine(Attack());
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
                _enemy = collision.gameObject;
                _state = STATE.ATTACK;
                _attackCoroutine = StartCoroutine(Attack());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
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
                    _enemy = GetCloserEnemy();

                }
                else
                {
                    _enemy = null;
                    _state = STATE.IDLE;
                    if (_attackCoroutine != null)
                        StopCoroutine(_attackCoroutine);
                }
            }
        }
    }


    private IEnumerator Attack()
    {
        do
        {
            if (_animator)
                _animator.SetTrigger("Attack");
            Player player = _enemy.GetComponent<Player>();
            if (player)
            {
                player.TakeDamage(_attackDamage);
            }
            else
            {
                Echoes echoes = _enemy.GetComponent<Echoes>();
                if (echoes)
                {
                    echoes.TakeDamage(_attackDamage);
                }
            }
            yield return new WaitForSeconds(_attackCooldown);
        }
        while (_enemy && OnRangeAttack());
        _state = STATE.IDLE;
        _attackCoroutine = null;
    }

    private bool OnRangeAttack()
    {
        return _enemy != null && Vector2.Distance(transform.position, _enemy.transform.position) <= _attackRange;
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
