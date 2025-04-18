using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDisruptor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.PlayerTag))
        {
            EchoesManager.SetIsEchoAllowed(false);
            NexusEnergy.instance.SetIsEnergyRegenerationAllowed(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.PlayerTag))
        {
            EchoesManager.SetIsEchoAllowed(true);
            NexusEnergy.instance.SetIsEnergyRegenerationAllowed(true);
        }
    }
}
