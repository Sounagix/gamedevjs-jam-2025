using UnityEngine;

public class BlueFireCheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.PlayerTag))
        {
            LevelSceneManager.instance.NextLevel();
        }
    }
}
