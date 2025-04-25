using UnityEngine;

public class NexusProjectile : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private int _damage;

    private bool _enemyCollision;

    private float _explosionRadius;

    private float _explosionForce;

    private GameObject _owner;


    public void SetUp(Vector2 dir, float speed, float lifeTime, int damage, float explosionRadius, float explosionForce, GameObject onwer)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _damage = damage;
        _explosionRadius = explosionRadius;
        _explosionForce = explosionForce;
        _rigidbody.velocity = dir * speed;
        _owner = onwer;
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
                if (d.TryGetComponent(out Enemy currentEnemy))
                {
                    currentEnemy.TakeDamage(_damage, _owner);
                }
                //else if (d.gameObject.TryGetComponent(out Player player))
                //{
                //    player.TakeDamage(_damage);
                //}
                else if (d.gameObject.TryGetComponent(out Echoes echo))
                {
                    echo.TakeDamage(_damage);
                }


                if (d.gravityScale > 0.0f)
                {
                    d.AddForce(((Vector2)hit.transform.position - position).normalized * _explosionForce, ForceMode2D.Impulse);
                }
            }
        }
        Destroy(gameObject);
    }
}
