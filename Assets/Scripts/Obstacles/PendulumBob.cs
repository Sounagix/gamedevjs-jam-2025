using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumBob : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude = 10f;

    [SerializeField]
    private float damage = 20f;

    private Life _life;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.PlayerTag) || collision.gameObject.CompareTag(PlayerActions.EnemyTag) || collision.gameObject.CompareTag("Echo"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 direction = (collision.transform.position - transform.position).normalized; // Direction Vector from pendulum to player

            rb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);

            // Take Damage
            _life = collision.gameObject.GetComponent<Life>();
            if (_life != null)
            {
                _life.TakeDamage(damage);
            }
        }
    }
}
