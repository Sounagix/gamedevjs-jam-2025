using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySiphon : MonoBehaviour
{
    [SerializeField]
    public float attractionRadius;

    [SerializeField]
    public float attractionStrength;

    [SerializeField]
    public float drainRate;

    [SerializeField]
    private LayerMask playerLayer;


    private void FixedUpdate()
    {
        // Check for the player using OverlapCircle
        Collider2D hit = Physics2D.OverlapCircle(transform.position, attractionRadius, playerLayer);

        if (hit == null) return; // No player in range

        // Get Rigidbody2D and apply force
        Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
        if (rb == null) return;

        Vector3 directionToPlayer = hit.transform.position - transform.position;
        float distance = directionToPlayer.magnitude;
        if (distance == 0) return;

        Vector3 pullDirection = directionToPlayer.normalized;
        float pullStrength = attractionStrength * (1f - (distance / attractionRadius));

        rb.AddForce(-pullDirection * pullStrength * Time.fixedDeltaTime, ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerActions.PlayerTag))
        {
            NexusEnergy.instance.SetIsEnergyRegenerationAllowed(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerActions.PlayerTag))
        {
            float energyToDrain = drainRate * Time.deltaTime;
            if (NexusEnergy.instance.CanUseEnergy(energyToDrain))
            {
                NexusEnergy.instance.UseEnergy(energyToDrain);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerActions.PlayerTag))
        {
            NexusEnergy.instance.SetIsEnergyRegenerationAllowed(true);
        }
    }


    private void OnDrawGizmosSelected()
    {
        // COOL VISUALIZATION 
        Gizmos.color = new Color(1f, 0.5f, 0f, 0.4f);
        Gizmos.DrawSphere(transform.position, attractionRadius);
    }
}
