using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private Scrollbar _energyBar;

    [SerializeField]
    private TMPro.TextMeshProUGUI _crystalCounterText;

    private int _numOfCrystals = 0;

    private void OnEnable()
    {
        PlayerActions.OnPlayerEnergyChanged += UpdateEnergyBar;
        PlayerActions.OnPlayerTouchCrystal += UpdateCrystalCounter;
    }



    private void OnDisable()
    {
        PlayerActions.OnPlayerEnergyChanged -= UpdateEnergyBar;
        PlayerActions.OnPlayerTouchCrystal -= UpdateCrystalCounter;
    }

    private void Start()
    {
        _energyBar.size = 1.0f;
        _crystalCounterText.text = "0";
    }

    private void UpdateEnergyBar(float value)
    {
        _energyBar.size = value;
    }

    private void UpdateCrystalCounter()
    {
        _numOfCrystals++;
        _crystalCounterText.text = _numOfCrystals.ToString();
    }
}
