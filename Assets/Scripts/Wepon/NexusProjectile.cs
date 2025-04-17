using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UIElements;

public class NexusProjectile : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private int _damage;

    private bool _enemyCollision;

    private float _explosionRadius;

    private float _explosionForce;

    public void SetUp(Vector2 dir, float speed, float lifeTime, int damage, float explosionRadius, float explosionForce)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _damage = damage;
        _explosionRadius = explosionRadius;
        _explosionForce = explosionForce;
        _rigidbody.velocity = dir * speed;
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _enemyCollision = true;
        CreateExplosion();
    }

    private void CreateExplosion()
    {
        Vector2 position = transform.position;
        PTCManager.instance.CretePTC(PTCType.EXPLOSION, position);
        Collider2D[] hits = Physics2D.OverlapCircleAll(position, _explosionRadius);
        foreach (Collider2D hit in hits)
        {
            Rigidbody2D d = hit.GetComponent<Rigidbody2D>();
            if (d != null)
            {
                Enemy currentEnemy = d.gameObject.GetComponent<Enemy>();
                if (currentEnemy)
                    currentEnemy.TakeDamage(_damage,gameObject);
                d.AddForce(((Vector2)hit.transform.position - position).normalized * _explosionForce, ForceMode2D.Impulse);
            }
        }
        Destroy(gameObject);
    }
}
