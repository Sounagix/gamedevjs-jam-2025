using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField]
    private float _maxLife;

    private float _currentLife;

    private void Start()
    {
        _currentLife = _maxLife;
    }

    public bool TakeDamage(float damage)
    {
        _currentLife -= damage;
        return _currentLife <= 0;
    }

    public void AddLife(float value)
    {
        _currentLife += value;
        if (_currentLife > _maxLife)
        {
            _currentLife = _maxLife;
        }
    }
}
