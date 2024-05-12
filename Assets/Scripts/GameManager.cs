using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Game settings
    public int complexity; // determines number spawn ticks occur on gamestart
    public int pickupFactor; // determines qty of pickup spawns, lower is better
    public int padFactor; // determines qty of pickup spawns, lower is better
    public int obstalceFactor; // determines qty of pickup spawns, lower is better

    public GameObject scoreTextArea;
    public GameObject resultsScoreTextArea;

    private int score;
    private bool scoreUpdatePending = false;
    Spawner spawner;

    // Ticker
    float interval = 1; // seconds between ticks
    int ticks = 0;

    private void Awake()
    {
        spawner = GetComponent<Spawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        for (int i = 0; i < complexity; i++)
        {
            if (i % pickupFactor == 0)
            {
                spawner.SpawnRandomPickup();
            }

            if (i % padFactor == 0)
            {
                spawner.SpawnRandomPad();
            }

            if (i % obstalceFactor == 0)
            {
                spawner.SpawnRandomObstacle();
            }
        }

    }

    void Update()
    {
        // Get UI element and update text to reflect new score
        if (!scoreUpdatePending)
        {
            // Apply update to score
            if (scoreTextArea != null)
            {
                TextMeshProUGUI scoreText = scoreTextArea.GetComponent<TextMeshProUGUI>();
                scoreText.SetText(score.ToString());
            }
            else
            {
                Debug.Log("Score Text has not been attached!");
            }
            scoreUpdatePending = true;
        }

        tick();
    }

    void OnTick()
    {
        spawner.SpawnRandomPickup();

        if (ticks % 1000 == 0)
        {
            spawner.SpawnRandomObstacle();
        }
    }

    public void increaseScore(int value) {
        score += value;
        scoreUpdatePending = false;
    }

    void tick()
    {
        int mod = (int) Mathf.Floor(Time.time);

        if (mod > ticks + interval)
        {
            ticks++;
            OnTick();
        }
    }

    public void ReloadGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowResults()
    {
        UIManager um = FindObjectOfType<UIManager>();
        Time.timeScale = 0;
        um.scoreUI.SetActive(false);
        // Get the results panel's text and set it the score
        TextMeshProUGUI scoreText = resultsScoreTextArea.GetComponent<TextMeshProUGUI>();
        scoreText.SetText(score.ToString());
        um.resultsUI.SetActive(true);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
