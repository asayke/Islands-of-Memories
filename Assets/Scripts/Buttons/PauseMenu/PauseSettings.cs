using Buttons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class PauseSettings : MonoBehaviour,IButton
    {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject settingsMenu;
        public void OnClick()
        {
            //pauseMenu.SetActive(false);
            //settingsMenu.SetActive(true);
            SceneManager.LoadScene(0);
        }
    }
}


