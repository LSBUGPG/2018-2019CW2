using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public bool isPauseMenu, hideCursor; //Check if the current controller is being used as a pause menu || Check if you have a game that hides and locks cursor in the game (e.g an FPS)
    bool gamePaused; //Used for Escape button inputs

    public List<GameObject> menuScreens = new List<GameObject>();  //Add any menu GameObject parents to this list - Startup screen should be on 0
    public List<string> scenes = new List<string>(); //Add any scene names to swap to to this list

    void Start()
    {
        Time.timeScale = 1;

        if (!isPauseMenu)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            for (int i = 0; i < menuScreens.Count; i++)
            {
                menuScreens[i].SetActive(false);

                if (i == 0)
                {
                    menuScreens[i].SetActive(true);
                }
            }
        }
        else
        {
            StopActiveScreens();
        }
    }

    void Update()
    {
        if (isPauseMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gamePaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void SwapActiveScene(int id)
    {
        SceneManager.LoadScene(scenes[id]);
    }

    public void SwapActiveScreen(int id)
    {
        for (int i = 0; i < menuScreens.Count; i++)
        {
            menuScreens[i].SetActive(false);

            if (i == id)
            {
                menuScreens[i].SetActive(true);
            }
        }
    }

    public void StopActiveScreens()
    {
        for (int i = 0; i < menuScreens.Count; i++)
        {
            menuScreens[i].SetActive(false);
        }
    }

    public void QuitGame()
    {
         Application.Quit();
    }

    public void Resume()
    {
        gamePaused = false;
        Time.timeScale = 1;
        StopActiveScreens();
        if (hideCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        gamePaused = true;
        SwapActiveScreen(0);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
  
