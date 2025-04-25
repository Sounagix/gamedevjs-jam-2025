using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFireCheckPoint : MonoBehaviour
{
    [SerializeField]
    private bool lastLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.PlayerTag) && !lastLevel)
        {
            LevelSceneManager.instance.NextLevel();
        }
        else if (collision.gameObject.CompareTag(PlayerActions.PlayerTag) && lastLevel)
        {
            LevelSceneManager.instance.LoadScene("WinGame");
        }
    }
}
