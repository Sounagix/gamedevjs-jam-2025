using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeleeEnemy : Attacker
{
    protected override IEnumerator AttackCoroutine()
    {
        if (_enemy != null)
        {
            _enemy.GetComponent<Player>().TakeDamage((int)_attackDamage);
            yield return new WaitForSecondsRealtime(_attackCooldown);
            _attackCoroutine = null;
        }        
    }
}
