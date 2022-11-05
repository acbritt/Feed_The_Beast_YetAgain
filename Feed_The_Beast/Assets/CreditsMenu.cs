using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    [SerializeField] GameObject pauseMenu;
    

    void Update()
    {
        if (Input.GetButtonDown("Credits Button"))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
        }
        else
        {
            PauseGame();
        }
    }

     public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void backToGame()
    {

    }
}
