using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NexusEnergy : MonoBehaviour
{
    [SerializeField]
    private float _maxEnergy;

    [SerializeField]
    private float _energyRegenerationRate;

    [SerializeField]
    private float _energyPercentageRegeneration;

    private float _currentEnergy;

    private bool energyRegenerationAllowed = true;

    public static NexusEnergy instance;

    private Coroutine _restartEnergyCoroutine;

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

    private void Start()
    {
        _currentEnergy = _maxEnergy;
    }

    public bool CanUseEnergy(float value)
    {
        return _currentEnergy >= value;
    }

    public void SetIsEnergyRegenerationAllowed(bool value)
    {
        energyRegenerationAllowed = value;

        if (!energyRegenerationAllowed && _restartEnergyCoroutine != null)
        {
            StopCoroutine(_restartEnergyCoroutine);
            _restartEnergyCoroutine = null;
        }
        else if (energyRegenerationAllowed && _currentEnergy < _maxEnergy && _restartEnergyCoroutine == null)
        {
            _restartEnergyCoroutine = StartCoroutine(AddEnergy());
        }
    }

    public void UseEnergy(float value)
    {
        if (CanUseEnergy(value))
        {
            _currentEnergy -= value;
            if (_currentEnergy < 0.0f)
            {
                _currentEnergy = 0.0f;
            }
            PlayerActions.OnPlayerEnergyChanged?.Invoke(_currentEnergy / _maxEnergy);
            if (energyRegenerationAllowed && (_restartEnergyCoroutine == null))
            {
                _restartEnergyCoroutine = StartCoroutine(AddEnergy());
            }
        }
    }

    public void AddEnergy(float value)
    {
        _currentEnergy += value;
        if (_currentEnergy > _maxEnergy)
        {
            _currentEnergy = _maxEnergy;
        }
    }

    private IEnumerator AddEnergy()
    {
        yield return new WaitForSeconds(_energyRegenerationRate);

        if (!energyRegenerationAllowed)
        {
            _restartEnergyCoroutine = null;
            yield break;
        }

        if (_currentEnergy < _maxEnergy)
        {
            float amountToAdd = _maxEnergy * _energyPercentageRegeneration;
            _currentEnergy = Mathf.Min(_currentEnergy + amountToAdd, _maxEnergy);
            PlayerActions.OnPlayerEnergyChanged?.Invoke(_currentEnergy / _maxEnergy);

            _restartEnergyCoroutine = StartCoroutine(AddEnergy());
        }
        else
        {
            _currentEnergy = _maxEnergy;
            PlayerActions.OnPlayerEnergyChanged?.Invoke(1f);
            _restartEnergyCoroutine = null;
        }
    }
}
