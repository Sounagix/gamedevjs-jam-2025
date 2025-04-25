using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTrEnemy : AttackerTr
{
    protected override IEnumerator AttackCoroutine()
    {
        if (_enemy != null)
        {
            if (_animator != null)
                _animator.SetTrigger("Attack");
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
