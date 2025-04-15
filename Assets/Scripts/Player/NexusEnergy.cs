using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NexusEnergy : MonoBehaviour
{
    [SerializeField]
    private float _maxEnergy;

    private float _currentEnergy;

    public static NexusEnergy instance;

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

    public void UseEnergy(float value)
    {
        if (CanUseEnergy(value))
        {
            _currentEnergy -= value;
            if (_currentEnergy < 0.0f)
            {
                _currentEnergy = 0.0f;
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
}
