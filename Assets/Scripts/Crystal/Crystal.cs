using UnityEngine;

public class Crystal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerActions.PlayerTag))
        {
            PlayerActions.OnPlayerTouchCrystal?.Invoke();
            Destroy(gameObject);
        }
    }
}
