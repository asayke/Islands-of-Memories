using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class PauseQuit : MonoBehaviour,IButton
    {
        public void OnClick()
        {
            Application.Quit();
        }
    }
}