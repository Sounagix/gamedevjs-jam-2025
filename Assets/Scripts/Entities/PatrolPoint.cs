using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    private Enemy _owner;

    private void Start()
    {
        _owner = transform.parent.parent.GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(_owner))
        {
            //collision.gameObject.GetComponent<Patroller>().NextPoint();
        }
    }
}
