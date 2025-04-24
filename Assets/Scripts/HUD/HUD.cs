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
    private Scrollbar _healthbar;

    [SerializeField] 
    private Life _playerLife;

    [SerializeField]
    private TMPro.TextMeshProUGUI _crystalCounterText;

    private int _numOfCrystals = 0;

    private void Update()
    {
        UpdateHealthBar((_playerLife._currentLife / _playerLife._maxLife));
    }

    private void OnEnable()
    {
        PlayerActions.OnPlayerEnergyChanged += UpdateEnergyBar;
        PlayerActions.OnPlayerTouchCrystal += UpdateCrystalCounter;    }



    private void OnDisable()
    {
        PlayerActions.OnPlayerEnergyChanged -= UpdateEnergyBar;
        PlayerActions.OnPlayerTouchCrystal -= UpdateCrystalCounter;
    }

    private void Start()
    {
        _energyBar.size = 1.0f;
        _healthbar.size = 1.0f;
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

    private void UpdateHealthBar(float value)
    {
        _healthbar.size = value;
    }
}
