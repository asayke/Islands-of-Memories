using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public partial class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            Cursor.lockState = pauseMenu.activeSelf ?  CursorLockMode.None : CursorLockMode.Locked ;
            Cursor.visible = pauseMenu.activeSelf;
        }
    }
}