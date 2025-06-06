using System.Collections;
using UnityEngine;

public class CasterEnemy : Attacker
{
    [SerializeField]
    private float _projectileSpeed;

    [SerializeField]
    private GameObject _projectilePrefab;

    protected override IEnumerator AttackCoroutine()
    {
        if (_animator)
            _animator.SetTrigger("Attack");
        Vector2 dir = (_enemy.transform.position - transform.position).normalized;
        GameObject projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<EnemyProjectile>().SetUp(dir, _projectileSpeed, 2.0f, _attackDamage);

        yield return new WaitForSeconds(_attackCooldown);
        _attackCoroutine = null;
    }
}
