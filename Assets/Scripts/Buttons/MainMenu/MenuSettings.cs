using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class MenuSettings : MonoBehaviour,IButton
    {
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject settingsMenu;

        public void OnClick()
        {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);
            
        }
        
    }
}