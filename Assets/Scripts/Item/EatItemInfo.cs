

using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "EatItemInfo", menuName = "EatItemInfo")]
public class EatItemInfo : ItemInfo
{
    [SerializeField] private float _healthValue = 0;
    [SerializeField] private float _thirstValue = 0;
    [SerializeField] private float _mealValue = 0;
    [SerializeField] private float _energyValue = 0;
    
    public float HealthValue => _healthValue;
    public float ThirstValue => _thirstValue;
    public float MealValue => _mealValue;
    public float EnergyValue => _energyValue;
}
