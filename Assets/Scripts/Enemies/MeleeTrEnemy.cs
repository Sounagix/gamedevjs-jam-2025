using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTrEnemy : AttackerTr
{
    protected override IEnumerator AttackCoroutine()
    {
        if (_enemy != null)
        {
            _enemy.GetComponent<Player>().TakeDamage((int)_attackDamage);
            yield return new WaitForSeconds(_attackCooldown);
            _attackCoroutine = null;
        }
        else
        {
            StopAttacking();
            StartPatrolling();
        }
    }
}
