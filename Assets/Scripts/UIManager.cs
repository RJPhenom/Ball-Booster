using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject scoreUI;
    public GameObject pauseUI;
    public GameObject resultsUI;

    private bool paused = false;
    private bool disabled = false;
    // Start is called before the first frame update
    void Start()
    {
        if (scoreUI != null)
        {
            scoreUI.SetActive(true);
        }
        if (pauseUI != null)
        {
            pauseUI.SetActive(false);
        }
        if (resultsUI != null)
        {
            resultsUI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!disabled)
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
    }

    private void PauseGame()
    {
        paused = true;
        Time.timeScale = 0;
        pauseUI.SetActive(true);
    }

    private void ResumeGame()
    {
        paused = false;
        // Original time scale should be stored somewhere
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }
}
