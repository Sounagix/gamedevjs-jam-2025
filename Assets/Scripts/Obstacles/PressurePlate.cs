using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private GateController gateController;
    private int objectsOnPlate = 0;

    private void Awake()
    {
        gateController = GetComponentInParent<GateController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.PlayerTag) || collision.gameObject.CompareTag("Echo"))
        {
            gateController.SetGateState(GateController.GateState.Open);
            objectsOnPlate++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.PlayerTag) || collision.gameObject.CompareTag("Echo"))
        {
            objectsOnPlate--;
        }
        if (objectsOnPlate == 0)
        {
            gateController.SetGateState(GateController.GateState.Closed);
        }
    }
}
