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
        if (!_thistBar.IsEmpty)
        {
            _thistBar.DecreaseValue(0.000096f);
        }

        if (!_mealBar.IsEmpty)
        {
            _mealBar.DecreaseValue(0.00006f); //0.00006f
        }
        
        if (!_energyBar.IsEmpty)
        {
            _energyBar.DecreaseValue(0.00001f);
        }
        
        if (_thistBar.IsEmpty || _mealBar.IsEmpty)
        {
            _healthBar.DecreaseValue(0.0008f);
        }
    }
}
