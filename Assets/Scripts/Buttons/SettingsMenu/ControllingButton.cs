using UnityEngine;

namespace Buttons.SettingsMenu
{
    public class ControllingButton : MonoBehaviour,IButton
    {
        [SerializeField] private GameObject notimplemented;
        public void OnClick()
        {
            notimplemented.SetActive(true);
            Invoke("DisableText",3.0f);
        }

        public void DisableText()
        {
            notimplemented.SetActive(false);
        }


    }
}