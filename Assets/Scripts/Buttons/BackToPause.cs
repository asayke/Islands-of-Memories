using UnityEngine;

namespace Buttons
{
    public class BackToPause : MonoBehaviour, IButton

    {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject settingsMenu;
        public void OnClick()
        {
            pauseMenu.SetActive(true);
            settingsMenu.SetActive(false);
            
        }
    }
}