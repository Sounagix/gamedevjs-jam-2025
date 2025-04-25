using System.Collections.Generic;
using UnityEngine;

public class Patroller : MovableEnemy
{
    private CircleCollider2D _lureRange;

    [SerializeField]
    protected float _lureDistance;

    [SerializeField]
    private float _patrolSpeed = 1.0f;

    private List<Vector2> _patrolPoints = new List<Vector2>();

    private int _currentPatrolPointIndex = 0;

    protected override void Awake()
    {
        base.Awake();
        _lureRange = GetComponent<CircleCollider2D>();
        _lureRange.radius = _lureDistance;
    }

    protected override void Start()
    {
        base.Start();
        StartPatrolling();
    }

    public override void StartPatrolling()
    {
        base.StartPatrolling();
        _currentSpeed = _patrolSpeed;
    }
}
