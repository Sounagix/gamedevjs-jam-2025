using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private GateController gateController;
    private SpriteRenderer spriteRenderer;
    private int objectsOnPlate = 0;

    [SerializeField]
    private Sprite idleSprite;

    [SerializeField]
    private Sprite activeSprite;

    private AudioSource _audioSource;

    private void Awake()
    {
        gateController = GetComponentInParent<GateController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.PlayerTag) || collision.gameObject.CompareTag("Echo"))
        {
            gateController.SetGateState(GateController.GateState.Open);
            objectsOnPlate++;
            spriteRenderer.sprite = activeSprite;
            _audioSource.Play();
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
            spriteRenderer.sprite = idleSprite;
        }
    }
}
