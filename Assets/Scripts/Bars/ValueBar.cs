using UnityEngine;
using UnityEngine.UI;
using static System.Math;

public class ValueBar : MonoBehaviour, IBar
{
    [SerializeField] protected Slider _slider;
    [SerializeField] protected Image _imageToFill;
    [SerializeField] protected Text _text;
    public Slider Slider => _slider;
    public Image Image => _imageToFill;
    public bool IsEmpty => _slider.value <= 0;

    public virtual void SetMaxValue(float value)
    {
        _slider.maxValue = value;
    }

    public virtual void DecreaseValue(float value)
    {
        _slider.value -= value;
        UpdateTextValue();
    }

    public virtual void IncreaseValue(float value)
    {
        if (_slider.value + value > _slider.maxValue)
            _slider.value = _slider.maxValue;
        else _slider.value += value;
        UpdateTextValue();
    }

    public virtual void UpdateTextValue()
    {
        if (_text != null)
            _text.text = $"{(int) _slider.value}/{(int)_slider.maxValue}";
    }
}


//TODO перенести в отдельный файл.
public interface IBar
{
    public Slider Slider { get; }

    public Image Image { get; }

    public bool IsEmpty { get; }

    public void SetMaxValue(float value);

    public void DecreaseValue(float value);

    public void IncreaseValue(float value);

    public void UpdateTextValue();
}