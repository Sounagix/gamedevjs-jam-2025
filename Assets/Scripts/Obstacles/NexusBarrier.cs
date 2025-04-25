using UnityEngine;

public class NexusBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("Explosion"))
        {
            Destroy(gameObject);
        }
    }
}
