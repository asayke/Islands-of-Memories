using UnityEngine;
using UnityEngine.UI;

public class ValueBar : MonoBehaviour, IBar
{
    [SerializeField] protected Slider _slider;
    [SerializeField] protected Image _imageToFill;
    
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
     }

     public virtual void IncreaseValue(float value)
     {
         _slider.value += value;
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
    
}