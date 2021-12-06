using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class Resume : MonoBehaviour, IButton
    {
        [SerializeField] private GameObject _menu;
        
        public void OnClick()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _menu.SetActive(false);
        }
    }
}