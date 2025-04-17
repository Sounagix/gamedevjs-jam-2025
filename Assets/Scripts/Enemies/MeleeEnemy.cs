using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeleeEnemy : Attacker
{
    protected override IEnumerator AttackCoroutine()
    {
        _enemy.GetComponent<Life>().TakeDamage((int)_attackDamage);
        yield return new WaitForSeconds(_attackCooldown);
        _attackCoroutine = null;
    }
}
