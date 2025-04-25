using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startPos, length;
    public GameObject cam;

    private void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float distance = cam.transform.position.x * 0.9f;
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
