using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class MenuSettings : MonoBehaviour,IButton
    {
        public void OnClick()
        {
            SceneManager.LoadScene(1);
        }
    }
}