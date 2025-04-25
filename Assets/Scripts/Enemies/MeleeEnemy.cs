using System.Collections;
using UnityEngine;

public class MeleeEnemy : Attacker
{
    protected override IEnumerator AttackCoroutine()
    {
        if (_enemy != null)
        {
            if (_animator)
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

            yield return new WaitForSecondsRealtime(_attackCooldown);
            _attackCoroutine = null;
        }
    }
}
