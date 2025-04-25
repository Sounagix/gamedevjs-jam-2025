using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    protected Player _player;

    [SerializeField]
    [Min(0.5f)]
    protected float _cooldown = 1f;

    [SerializeField]
    protected float _damage = 1f;

    protected float _nextDamageTime = -Mathf.Infinity;


    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.PlayerTag))
        {
            _player = collision.gameObject.GetComponent<Player>();
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.PlayerTag))
        {
            if (Time.time >= _nextDamageTime)
            {
                _nextDamageTime = Time.time + _cooldown;
                _player.TakeDamage(_damage);
            }
        }
    }
}
