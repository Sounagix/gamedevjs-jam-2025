using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PTCType
{
    EXPLOSION,

}

public class PTCManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionPrefab;

    public static PTCManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CretePTC(PTCType pTCType, Vector2 position)
    {
        switch (pTCType)
        {
            case PTCType.EXPLOSION:
                GameObject ptc = Instantiate(_explosionPrefab, position, Quaternion.identity);
                Destroy(ptc, 1f);
                break;
        }
    }
}
