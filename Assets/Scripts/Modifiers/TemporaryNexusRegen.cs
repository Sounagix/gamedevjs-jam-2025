using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryNexusRegen : MonoBehaviour
{
    [SerializeField]
    private float timeForRegen = 5f;

    private bool _oldNexusEnergyAllowed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerActions.PlayerTag))
        {
            StartCoroutine(RegerateNexus());
            Destroy(gameObject);
        }
    }

    private IEnumerator RegerateNexus()
    {
        _oldNexusEnergyAllowed = NexusEnergy.instance.energyRegenerationAllowed;
        NexusEnergy.instance.SetIsEnergyRegenerationAllowed(true);
        yield return new WaitForSeconds(timeForRegen);
        NexusEnergy.instance.SetIsEnergyRegenerationAllowed(_oldNexusEnergyAllowed);
    }
}
