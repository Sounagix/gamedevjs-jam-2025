using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronoKnight : CasterEnemy
{
    public override void TakeDamage(int damage, GameObject enemy)
    {
        Vector2 attackerDir = (enemy.transform.position - transform.position).normalized;
        if ((_dir.x > 0f && attackerDir.x < 0f) || (_dir.x < 0f && attackerDir.x > 0f))
        {
            base.TakeDamage(damage, enemy);
        }

    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Echoes echoes = collision.GetComponent<Echoes>();
        if (echoes)
        {
            SetEnemy(echoes.gameObject);
        }
        else
        {
            base.OnTriggerEnter2D(collision);
        }

    }
}
