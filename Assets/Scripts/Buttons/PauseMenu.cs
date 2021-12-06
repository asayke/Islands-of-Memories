using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            Cursor.lockState = pauseMenu.activeSelf ?  CursorLockMode.None : CursorLockMode.Locked ;
            Cursor.visible = pauseMenu.activeSelf;
        }
    
    }
}