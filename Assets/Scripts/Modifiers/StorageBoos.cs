using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBoos : MonoBehaviour
{
    [SerializeField]
    private float timeForStorageBoost = 60f;

    private float _prevMaxEnergy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerActions.PlayerTag))
        {
            StartCoroutine(GiveExtraStorage());
            Destroy(gameObject);
        }
    }

    private IEnumerator GiveExtraStorage()
    {
        _prevMaxEnergy = NexusEnergy.instance.GetMaxEnergy();
        NexusEnergy.instance.SetMaxEnergy(150f);
        yield return new WaitForSeconds(timeForStorageBoost);
        NexusEnergy.instance.SetMaxEnergy(_prevMaxEnergy);
    }
}
