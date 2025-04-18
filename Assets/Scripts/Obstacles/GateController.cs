using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public enum GateState
    {
        Closed,
        Open
    }

    public GateState CurrentState { get; private set; } = GateState.Closed;

    private Collider2D gateCollider;

    private void Awake()
    {
        gateCollider = GetComponentInChildren<Collider2D>();
    }

    public void SetGateState(GateState newState)
    {
        if (newState == CurrentState) return;
        CurrentState = newState;
        bool isTrigger = (newState == GateState.Open);
        gateCollider.isTrigger = isTrigger; // Make gate pass-through when open
    }
}
