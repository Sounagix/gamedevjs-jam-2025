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

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private GameObject gate;

    [SerializeField]
    private Sprite closedSprite;

    [SerializeField]
    private Sprite openSprite;

    private void Awake()
    {
        gateCollider = gate.GetComponent<Collider2D>();
        spriteRenderer = gate.GetComponent<SpriteRenderer>();
    }

    public void SetGateState(GateState newState)
    {
        if (newState == CurrentState) return;
        CurrentState = newState;
        gateCollider.isTrigger = (newState == GateState.Open); // Make gate pass-through when open

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = (newState == GateState.Open) ? openSprite : closedSprite; // USe the open sprite when gate is open else close
        }
    }
}
