using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject activePanel;
    public GameObject pausePanel;
    public GameObject resumePanel;

    private bool started = false;
    private bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        if (startPanel != null)
        {
            startPanel.SetActive(true);
        }  
        if (activePanel != null)
        {
            activePanel.SetActive(false);
        }
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
        resumePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!paused)
                {
                    PauseGame();
                }
                else
                {
                    ResumeGame();
                }

            }
            return;
        }

        // The game has not started
        if (Input.anyKey)
        {
            started = true;

        }
        
    }

    private void StartGame()
    {
        startPanel.SetActive(false);
        activePanel.SetActive(true);
    }

    private void StopGame()
    {
        // Get the results panel's text and set it the score
        resumePanel.SetActive(true);
        activePanel.SetActive(false);
    }

    private void PauseGame()
    {
        paused = true;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    private void ResumeGame()
    {
        paused = false;
        // Original time scale should be stored somewhere
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
