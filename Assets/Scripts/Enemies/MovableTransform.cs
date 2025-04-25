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
        if (_state.Equals(STATE.MOVE) && _targetTr && !OnDistanceToStop())
        {
            _dir = (_targetTr.position - transform.position).normalized;
            transform.position = transform.position + (Vector3)(_dir * _speed * Time.deltaTime);
        }
        else if (_targetTr && OnDistanceToStop())
        {
            _state = STATE.ATTACK;
        }
    }
}
