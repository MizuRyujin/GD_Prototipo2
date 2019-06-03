using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool GamePaused = false;
    public GameObject PauseScreen;


    // Update every frame
    private void Update()
    {
        // Gets back in game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GamePaused)
            {
                Resume();
            }
        }
        // If not paused
        else if (Input.GetKeyDown(KeyCode.P))
        {
            if (!GamePaused)
            {
                isPause();
            }
        }
        Restart();
        Quit();
    }

    // Resumes game
    public void Resume()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    // Pauses game
    public void isPause()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    // Restarts game if pressed R
    public void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    // Quits game if pressed Q
    public void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
}