using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echoes : MonoBehaviour
{
    [SerializeField]
    private float _tauntDistance;

    private CircleCollider2D _circleCollider2D;

    private EchoSounds _echoSounds;

    private Life _life;

    private void Awake()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.radius = _tauntDistance;
        _echoSounds = GetComponent<EchoSounds>();
        _life = GetComponent<Life>();
    }

    private void Start()
    {
        _echoSounds.PlaySound(ECHO_SOUNDS.SPAWN);
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

    public void TakeDamage(int damage)
    {
        _echoSounds.PlaySound(ECHO_SOUNDS.HURT);
        if (_life.TakeDamage(damage))
        {
            Die();
        }
    }

    private void Die()
    {
        _echoSounds.PlaySound(ECHO_SOUNDS.DEATH);
        // add animation timer
        Destroy(gameObject);
    }
}
