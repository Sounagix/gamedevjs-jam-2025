using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableTransform : Enemy
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _maxSpeed;

    private Transform _targetTr;

    protected float _distanceToStop;

    protected Vector2 _dir = Vector2.right;

    protected SpriteRenderer _spriteRenderer;


    protected override void Awake()
    {
        base.Awake();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
    }

    protected virtual void StartPatrolling()
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
        //if (_targetTr != null && !OnDistanceToStop() && rb.velocity.magnitude < _maxSpeed)
        //{
        //    _dir = (_targetTr.position - transform.position).x >= 0.0f ? Vector2.right : Vector2.left;
        //    rb.velocity = _dir * _speed;
        //}
        //else if (_state.Equals(STATE.PATROLING) && rb.velocity.magnitude < _maxSpeed)
        //{
        //    Vector2 initpos = (Vector2)transform.position + (_dir * 1.5f);
        //    Debug.DrawLine(initpos, initpos + (initpos * Vector2.down * 3.0f), Color.red, 0.1f);
        //    RaycastHit2D hit = Physics2D.Raycast(initpos, Vector2.down, 3.0f, LayerMask.GetMask(PlayerActions.GroundTag));
        //    if (hit && hit.collider.CompareTag(PlayerActions.GroundTag))
        //    {
        //        rb.velocity = _dir * _speed;
        //    }
        //    else
        //    {
        //        _dir = -_dir;
        //        _spriteRenderer.flipX = _dir.x < 0.0f;
        //        rb.velocity = _dir * _speed;
        //    }

        //}
    }
}
