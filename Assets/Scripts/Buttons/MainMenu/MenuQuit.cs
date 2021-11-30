using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public partial class MenuQuit : MonoBehaviour,IButton
    {
        public void OnClick()
        {
            Application.Quit();
        }
    }
}