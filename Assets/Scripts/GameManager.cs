using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Game settings
    public int complexity; // determines number of pads and stuff spawned at start

    public GameObject scoreTextArea;

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
            spawner.SpawnRandomNoPickups();

            if (i % 2 == 0)
            {
                spawner.SpawnRandomPickup();
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

        if (ticks % 5 == 0)
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
}
