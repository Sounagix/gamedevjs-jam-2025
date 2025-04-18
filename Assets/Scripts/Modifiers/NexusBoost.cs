using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NexusBoost : MonoBehaviour
{
    [SerializeField]
    private float boost = 50f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerActions.PlayerTag))
        {
            NexusEnergy.instance.AddEnergy(boost);
            Destroy(gameObject);
        }
    }
}
