using Buttons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class PauseSettings : MonoBehaviour,IButton
    {
        public void OnClick()
        {
            SceneManager.LoadScene(3);
        }
    }
}


