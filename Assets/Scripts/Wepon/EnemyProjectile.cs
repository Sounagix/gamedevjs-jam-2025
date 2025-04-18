using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    private Rigidbody2D _rigidbody;
    private int _damage;


    public void SetUp(Vector2 dir, float speed, float lifeTime, int damage)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _damage = damage;
        _rigidbody.velocity = dir * speed;
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerActions.PlayerTag))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(_damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag(PlayerActions.GroundTag))
        {
            Destroy(gameObject);
        }
    }
}
