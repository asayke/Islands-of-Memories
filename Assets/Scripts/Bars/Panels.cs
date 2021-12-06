using System;
using UnityEngine;


public class Panels : MonoBehaviour
{
    [SerializeField] public ValueBar HealthBar;
    [SerializeField] public ValueBar ThistBar;
    [SerializeField] public ValueBar MealBar;
    [SerializeField] public ValueBar EnergyBar;

    private void Awake()
    {
        HealthBar.SetMaxValue(100.05f);
        HealthBar.SetValue(50);
        ThistBar.SetMaxValue(100.05f); 
        ThistBar.SetValue(35);
        MealBar.SetMaxValue(100.05f);
        MealBar.SetValue(50);
        EnergyBar.SetMaxValue(100.05f);
        EnergyBar.SetValue(67);
    }

    private void Update()
    {
        if (!ThistBar.IsEmpty)
        {
            ThistBar.DecreaseValue(0.000096f);
        }

        if (!MealBar.IsEmpty)
        {
            MealBar.DecreaseValue(0.00006f); //0.00006f
        }
        
        if (!EnergyBar.IsEmpty)
        {
            EnergyBar.DecreaseValue(0.00001f);
        }
        
        if (ThistBar.IsEmpty || MealBar.IsEmpty)
        {
            HealthBar.DecreaseValue(0.0008f);
        }
    }
}
