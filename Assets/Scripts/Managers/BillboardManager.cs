using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BillboardManagerActions
{
    public static Action<Vector2, string> OnBillboardCreated;
}

public class BillboardManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _billboardPrefab;

    private void OnEnable()
    {
        BillboardManagerActions.OnBillboardCreated += CreateBillboard;
    }

    private void OnDisable()
    {
        BillboardManagerActions.OnBillboardCreated -= CreateBillboard;
    }

    private void CreateBillboard(Vector2 pos, string value)
    {
        Instantiate(_billboardPrefab, pos, Quaternion.identity)
            .GetComponent<Billboard>()
            .SetUp(value);
    }
}
