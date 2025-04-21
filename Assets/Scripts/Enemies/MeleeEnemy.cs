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
            Player player = _enemy.GetComponent<Player>();
            if (player)
            {
                player.TakeDamage((int)_attackDamage);
            }
            else
            {
                Echoes echoes = _enemy.GetComponent<Echoes>();
                if (echoes)
                {
                    echoes.TakeDamage((int)_attackDamage);
                }
            }

            yield return new WaitForSecondsRealtime(_attackCooldown);
            _attackCoroutine = null;
        }        
    }
}
