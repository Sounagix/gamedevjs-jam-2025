using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField]
    public Camera mainCamera;

    [SerializeField]
    public AnimationCurve shakeCurve;

    [SerializeField]
    public float duration = 1f;
    
    public void Shake()
    {
        StartCoroutine(Shaking());
    }

    private IEnumerator Shaking()
    {
        Vector2 startPos = mainCamera.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = shakeCurve.Evaluate(elapsedTime / duration);
            mainCamera.transform.position = startPos = Random.insideUnitSphere * strength;
            yield return null;
        }

        mainCamera.transform.position = startPos;
    }
}
