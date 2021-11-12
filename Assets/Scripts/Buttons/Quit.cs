using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class Quit : MonoBehaviour,IButton
    {
        public void OnClick()
        {
            Application.Quit();
        }
    }
}