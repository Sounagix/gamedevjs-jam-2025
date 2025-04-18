using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTrEnemy : AttackerTr
{
    protected override IEnumerator AttackCoroutine()
    {
        if (_enemy)
        {
            _enemy.GetComponent<Life>().TakeDamage((int)_attackDamage);
            yield return new WaitForSeconds(_attackCooldown);
        }
        else
        {
            StopAttacking();
            StartPatrolling();
        }
        _attackCoroutine = null;
    }
}
