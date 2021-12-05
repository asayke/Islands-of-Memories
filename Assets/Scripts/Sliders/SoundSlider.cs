using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sliders
{
    public class SoundSlider : MonoBehaviour 
    {
        [SerializeField] private Slider slider;
        [SerializeField] private GameObject camera;

        private void Update()
        {
            camera.GetComponent<AudioSource>().volume = slider.value;
        }
    }
}