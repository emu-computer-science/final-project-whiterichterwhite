using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pausePanel;
    public GameObject inventoryPanel;
    public bool usePausePanel;


    //void Start()
    //{
    //    isPaused = false;
    //    pausePanel.SetActive(false);
    //    inventoryPanel.SetActive(false);
    //    usePausePanel = false;
    //}


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused)
            {
                Resume();
            }
            else {
                Pause();
            }
           ;        
        }
    }

    public void Resume() {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause() {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        usePausePanel = true;
    }

    //method to be used when we have our main menu scene actually made
    public void mainMenu()
    {
        //whatever our actual main menu scene is going to be
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f;
    }

    public void SwitchPanel() {
        usePausePanel = !usePausePanel;
        if (usePausePanel)
        {
            pausePanel.SetActive(true);
            inventoryPanel.SetActive(false);
        }
        else {
            inventoryPanel.SetActive(true);
            pausePanel.SetActive(false);
        }
    }
}
