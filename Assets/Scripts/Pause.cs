using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;

    private bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!paused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
            
        }
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
