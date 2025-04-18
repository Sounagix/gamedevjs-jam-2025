using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    private Life _life;

    [SerializeField]
    private float cooldown = 1f;

    [SerializeField]
    private float damage = 5f;

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
        _life = gameObject.GetComponent<Life>();
        _life.TakeDamage(damage);
    }
}
