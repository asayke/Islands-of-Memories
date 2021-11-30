using System;
using UnityEngine;


public class Panels : MonoBehaviour
{
    [SerializeField] private ValueBar _healthBar;
    [SerializeField] private ValueBar _thistBar;
    [SerializeField] private ValueBar _mealBar;
    [SerializeField] private ValueBar _energyBar;

    private void Awake()
    {
        _healthBar.SetMaxValue(100);
        _thistBar.SetMaxValue(100);
        _mealBar.SetMaxValue(100);
        _energyBar.SetMaxValue(100);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _healthBar.DecreaseValue(7);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            _thistBar.IncreaseValue(100f);
        }
        
        if (!_thistBar.IsEmpty)
        {
            _thistBar.DecreaseValue(0.001f/2f); //0.0005f подходит нормально
        }

        if (!_mealBar.IsEmpty)
        {
            _mealBar.DecreaseValue(0.004f/2f);
        }

        if (_thistBar.IsEmpty || _mealBar.IsEmpty)
        {
            _healthBar.DecreaseValue(0.005f);
        }
        if (!_energyBar.IsEmpty)
        {
            _energyBar.DecreaseValue(0.0001f/2f);
        }
    }
}
