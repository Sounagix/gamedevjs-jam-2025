using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private Scrollbar _energyBar;

    private void OnEnable()
    {
        PlayerActions.OnPlayerEnergyChanged += UpdateEnergyBar;
    }

    private void OnDisable()
    {
        PlayerActions.OnPlayerEnergyChanged -= UpdateEnergyBar;
    }

    private void Start()
    {
        _energyBar.size = 1.0f;
    }

    private void UpdateEnergyBar(float value)
    {
        _energyBar.size = value;
    }
}
