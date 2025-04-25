using System.Collections;
using UnityEngine;

public class DestroyablePlatform : Platform
{
    [SerializeField]
    private float _destroyDelay;

    private Coroutine _destroyCoroutine;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.PlayerTag))
        {
            _destroyCoroutine = StartCoroutine(DestroyPlatform());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerActions.PlayerTag) && _destroyCoroutine != null)
        {
            StopCoroutine(_destroyCoroutine);
        }
    }

    private IEnumerator DestroyPlatform()
    {
        yield return new WaitForSeconds(_destroyDelay);
        Destroy(gameObject);
    }
}
