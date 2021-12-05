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
        ThistBar.SetMaxValue(100.05f); 
        MealBar.SetMaxValue(100.05f);
        EnergyBar.SetMaxValue(100.05f);
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
