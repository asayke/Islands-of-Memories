using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sliders
{
    public class SoundSlider : MonoBehaviour 
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private AudioSource _source;
        //
        // private void Update()
        // {
        //     _source.volume = _slider.value;
        // }
    }
}