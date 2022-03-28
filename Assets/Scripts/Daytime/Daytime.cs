using System;
using UnityEngine;

namespace Daytime
{
    [ExecuteInEditMode]
    public class Daytime : MonoBehaviour
    {
        [SerializeField]  Gradient directionaliLightGradient;
        [SerializeField] private Gradient ambientLightGragient;

        [SerializeField, Range(1, 3600)] private float timeDayInSeconds = 60;
        [SerializeField, Range(0f, 1f)] private float timeProgress;

        [SerializeField]  Light dirLight;
        private Vector3 defaultAngles;
        private void Start() => defaultAngles = dirLight.transform.localEulerAngles;

        private void Update()
        {
            if(Application.isPlaying)
                 timeProgress += Time.deltaTime / timeDayInSeconds;

            if (timeProgress > 1f)
                timeProgress = 0f;

            dirLight.color = directionaliLightGradient.Evaluate(timeProgress);
            RenderSettings.ambientLight = ambientLightGragient.Evaluate(timeProgress);

            dirLight.transform.localEulerAngles = new Vector3(360f * timeProgress - 90, defaultAngles.x, defaultAngles.z); 
        }
    }
    }