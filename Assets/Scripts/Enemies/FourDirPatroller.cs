using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourDirPatroller : MovableTransform
{
    private List<Vector2> _patrolPoints = new List<Vector2>();

    private int _currentPatrolPointIndex = 0;

    [SerializeField]
    private float _patrolSpeed = 1f;

    [SerializeField]
    private float _patrolPause;

    private Coroutine _patrolCoroutine;

    protected override void Start()
    {
        base.Start();
        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                _patrolPoints.Add(child.position);
            }
        }
        StartPatrolling();
    }

    protected override void StartPatrolling()
    {
        _state = STATE.PATROLING;
        _patrolCoroutine = StartCoroutine(Patrolling());
    }


    private IEnumerator Patrolling()
    {
        while (_state.Equals(STATE.PATROLING))
        {
            Vector2 objetivo = _patrolPoints[_currentPatrolPointIndex];
            transform.position = Vector2.MoveTowards(transform.position, objetivo, Time.deltaTime * _patrolSpeed);

            if (Vector2.Distance(transform.position, objetivo) < 0.05f)
            {
                _currentPatrolPointIndex = (_currentPatrolPointIndex + 1) % _patrolPoints.Count;
                yield return new WaitForSeconds(_patrolPause);
            }

            yield return null;
        }
    }
}
