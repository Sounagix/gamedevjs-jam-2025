using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MeleeEnemy
{
    public override void TakeDamage(int damage, GameObject enemy)
    {
        NexusProjectile nexusProjectile = enemy.GetComponent<NexusProjectile>();
        if (nexusProjectile)
        {
            base.TakeDamage(damage, enemy);
        }
    }
}
