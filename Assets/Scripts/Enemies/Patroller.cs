using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MovableEnemy
{
    private CircleCollider2D _lureRange;

    [SerializeField]
    protected float _lureDistance;

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
}
