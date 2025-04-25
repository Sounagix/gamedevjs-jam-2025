using System.Collections.Generic;
using UnityEngine;

public class EchoesManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _echoPrefab;

    [SerializeField]
    private float _echoDuration;

    [SerializeField]
    private float _echoCost;

    private static bool echoAllowed = true;

    private List<Echoes> _echoes = new List<Echoes>();

    private void OnEnable()
    {
        EchoesActions.OnCreateEcho += CreateEcho;
        EchoesActions.OnEchoDie += RemoveEcho;
    }

    private void OnDisable()
    {
        EchoesActions.OnCreateEcho -= CreateEcho;
        EchoesActions.OnEchoDie -= RemoveEcho;
    }

    private void CreateEcho(Vector2 pos)
    {
        if (echoAllowed)
        {
            if (NexusEnergy.instance.CanUseEnergy(_echoCost))
            {
                NexusEnergy.instance.UseEnergy(_echoCost);
                Echoes echo = Instantiate(_echoPrefab, pos, Quaternion.identity, transform).GetComponent<Echoes>();
                _echoes.Add(echo);
                echo.SetUp(_echoDuration);
            }
        }
    }

    public static void SetIsEchoAllowed(bool isEchoAllowed)
    {
        echoAllowed = isEchoAllowed;
    }

    public void RemoveEcho(Echoes echo)
    {
        if (_echoes.Contains(echo))
        {
            _echoes.Remove(echo);
        }
    }

    public Echoes GetLastEcho()
    {
        return _echoes.Count > 0 ? _echoes[_echoes.Count - 1] : null;
    }
}
