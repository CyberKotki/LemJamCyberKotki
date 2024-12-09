using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
        else
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
        }
        
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
}

// use if (!PauseControl.gameIsPaused) {} to disable inputs