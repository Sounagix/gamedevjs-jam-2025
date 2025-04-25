using UnityEngine;

public class PendulumBob : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude = 10f;

    [SerializeField]
    private float damage = 20f;

    private Player _player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.PlayerTag) || collision.gameObject.CompareTag(PlayerActions.EnemyTag) || collision.gameObject.CompareTag(PlayerActions.EchoTag))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 direction = (collision.transform.position - transform.position).normalized; // Direction Vector from pendulum to player

            rb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);

            // Take Damage
            _player = collision.gameObject.GetComponent<Player>();
            if (_player != null)
            {
                _player.TakeDamage(damage);
            }
        }
    }
}
