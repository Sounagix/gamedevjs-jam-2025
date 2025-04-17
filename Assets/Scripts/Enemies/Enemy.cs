using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE
{
    IDLE,
    ATTACK,
    MOVE,
    PATROLING,
    FALLING,
    DIE
}


[RequireComponent(typeof(Life))]
public abstract class Enemy : MonoBehaviour
{
    protected Life _life;

    protected STATE _state = STATE.IDLE;

    protected virtual void Awake()
    {
        _life = GetComponent<Life>();
    }

    protected virtual void Start()
    {
    }

    public virtual void TakeDamage(int damage, GameObject enemy)
    {
        if (_life.TakeDamage(damage))
            Die();
    }

    public virtual void Die()
    {
        // Implement enemy death logic here
        Destroy(gameObject);
    }
}
