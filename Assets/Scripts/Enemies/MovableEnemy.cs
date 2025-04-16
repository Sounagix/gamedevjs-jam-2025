using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovableEnemy : Enemy
{
    [SerializeField]
    private float _speed;

    private Transform _targetTr;

    private Rigidbody2D rb;

    protected float _distanceToStop;

    protected GameObject _currentPlatform;

    protected Vector2 _dir;


    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject target)
    {
        _state = STATE.MOVE;
        _targetTr = target.transform;
    }

    public void StopMoving()
    {
        _state = STATE.IDLE;
        _targetTr = null;
        rb.velocity = Vector3.zero;
    }

    public void StartPatrolling()
    {
        _state = STATE.PATROLING;
        _dir = Vector2.right;
    }

    private bool OnDistanceToStop()
    {
        return Vector2.Distance(transform.position, _targetTr.position) < _distanceToStop;
    }

    protected virtual void LateUpdate()
    {
        if (_targetTr != null && !OnDistanceToStop())
        {
            _dir = (_targetTr.position - transform.position).x >= 0.0f ? Vector2.right : Vector2.left;
            rb.velocity = _dir.normalized * _speed;
        }
        else if (_state.Equals(STATE.PATROLING))
        {
            Vector2 initpos = (Vector2)transform.position + (_dir * 1.5f);
            Debug.DrawLine(initpos, initpos + (initpos * Vector2.down * 3.0f), Color.red, 0.1f);
            RaycastHit2D hit = Physics2D.Raycast(initpos, Vector2.down, 3.0f, LayerMask.GetMask(PlayerActions.GroundTag));
            if (hit && hit.collider.CompareTag(PlayerActions.GroundTag))
            {
                rb.velocity = _dir.normalized * _speed;
            }
            else
            {
                _dir = -_dir;
                rb.velocity = _dir.normalized * _speed;
            }
        
        }
    }
}
