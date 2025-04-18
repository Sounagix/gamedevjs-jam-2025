using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echoes : MonoBehaviour
{
    [SerializeField]
    private float _tauntDistance;

    private CircleCollider2D _circleCollider2D;

    private void Awake()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.radius = _tauntDistance;
    }

    public void SetUp(float lifeTime)
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerActions.EnemyTag))
        {
            collision.gameObject.GetComponent<Enemy>().SetTaunt(gameObject);
        }
    }

    private void OnDestroy()
    {
        EchoesActions.OnEchoDie?.Invoke(this);
    }
}
