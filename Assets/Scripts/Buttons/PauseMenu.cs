using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
    
    {
        //[SerializeField] private GameObject _settingsMenu;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {   
                if (SceneManager.GetActiveScene().buildIndex == 1)
                    SceneManager.LoadScene(2);
                else if (SceneManager.GetActiveScene().buildIndex == 2)
                    SceneManager.LoadScene(1);
            }
        }
    }
