using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NexusBarrier : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
