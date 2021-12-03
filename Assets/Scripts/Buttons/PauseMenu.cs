using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
    
    {
        [SerializeField] private GameObject pauseMenu;
        private void Update()
        {   
            if (Input.GetKeyDown(KeyCode.Escape))
                pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }
