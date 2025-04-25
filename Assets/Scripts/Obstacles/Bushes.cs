using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bushes : MonoBehaviour
{
    [SerializeField]
    private float cooldown = 1f;

    [SerializeField]
    private float damage = 1f;

    private float nextDamageTime = -Mathf.Infinity;

    private void OnTriggerStay2D(Collider2D collision)
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
