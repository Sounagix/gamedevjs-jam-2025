using System;
using System.Collections;
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

    private void OnEnable()
    {
        EchoesActions.OnCreateEcho += CreateEcho;
    }

    private void OnDisable()
    {
        EchoesActions.OnCreateEcho -= CreateEcho;
    }

    private void CreateEcho(Vector2 pos)
    {
        if (echoAllowed)
        {
            if (NexusEnergy.instance.CanUseEnergy(_echoCost))
            {
                NexusEnergy.instance.UseEnergy(_echoCost);
                Echoes echo = Instantiate(_echoPrefab, pos, Quaternion.identity, transform).GetComponent<Echoes>();
                echo.SetUp(_echoDuration);
            }
        }
    }

    public static void SetIsEchoAllowed(bool isEchoAllowed)
    {
        echoAllowed = isEchoAllowed;
    }
}
