using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protector : MeleeEnemy
{
    private CircleCollider2D _lureRange;


    protected override void Awake()
    {
        base.Awake();
        _lureRange = GetComponent<CircleCollider2D>();
        _lureRange.radius = _lureDistance;
    }

    private void Start()
    {
        StartPatrolling();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerActions.PlayerTag))
        {
            SetEnemy(collision.gameObject);
        }
        else if (collision.CompareTag(PlayerActions.GroundTag))
        {
            _currentPlatform = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerActions.PlayerTag))
        {
            StopAttacking();
            StopMoving();
            _state = STATE.PATROLING;
        }
    }
}
