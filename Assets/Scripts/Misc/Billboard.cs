using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshPro _billboardText;

    [SerializeField]
    private float _lifeTime;

    [SerializeField]
    private float _speed;

    public void SetUp(string value)
    {
        _billboardText.text = value;
        Destroy(gameObject, _lifeTime);
    }

    private void LateUpdate()
    {
        transform.position = transform.position + Vector3.up * _speed * Time.deltaTime;
    }
}
