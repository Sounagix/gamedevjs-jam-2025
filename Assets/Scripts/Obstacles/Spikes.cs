using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField]
    private float cooldown = 1f;

    [SerializeField]
    private float damage = 10f;

    private float nextDamageTime = -Mathf.Infinity;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.PlayerTag))
        {
            if (Time.time >= nextDamageTime)
            {
                nextDamageTime = Time.time + cooldown;
                GiveDamage(damage, collision.gameObject);
            }
        }
    }

    void GiveDamage(float damage, GameObject gameObject)
    {
        gameObject.GetComponent<Player>().TakeDamage(damage);
    }
}
