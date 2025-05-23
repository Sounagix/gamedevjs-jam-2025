using System.Collections;
using UnityEngine;

public class NexusEnergy : MonoBehaviour
{
    [SerializeField]
    private float _maxEnergy;

    [SerializeField]
    private float _energyRegenerationRate;

    [SerializeField]
    private float _energyPercentageRegeneration;

    private PlayerSounds _playerSounds;

    private float _currentEnergy;

    public bool energyRegenerationAllowed = true;

    public static NexusEnergy instance;

    private Coroutine _restartEnergyCoroutine;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            _playerSounds = GetComponent<PlayerSounds>();
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
        if (_currentEnergy >= value)
        {
            return true;
        }
        _playerSounds.PlayOnShot(PLAYER_SOUNDS.ERROR);
        return false;
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

    public float GetMaxEnergy()
    {
        return _maxEnergy;
    }

    public void SetMaxEnergy(float newMax)
    {
        _maxEnergy = newMax;
        _currentEnergy = Mathf.Min(_currentEnergy, _maxEnergy);
        PlayerActions.OnPlayerEnergyChanged?.Invoke(_currentEnergy / _maxEnergy);
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

    public void DrainEnergy()
    {
        _currentEnergy = 0;
    }
}
