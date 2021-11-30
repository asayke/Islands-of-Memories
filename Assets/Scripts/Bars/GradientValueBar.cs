
using System;
using UnityEngine;

public class GradientValueBar : ValueBar
{
    [SerializeField] private Gradient _gradient;
    
    public override void SetMaxValue(float value)
    {
        base.SetMaxValue(value);
        _imageToFill.color = _gradient.Evaluate(1f);
    }
    public override void DecreaseValue(float value)
    {
        base.DecreaseValue(value);
        _imageToFill.color = _gradient.Evaluate(_slider.normalizedValue);
    }

    public override void IncreaseValue(float value)
    {
        base.IncreaseValue(value);
        _imageToFill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}