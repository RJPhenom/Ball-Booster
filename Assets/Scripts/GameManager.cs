using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject scoreTextArea;

    private int score;
    private bool scoreUpdatePending = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
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
    }

    public void increaseScore(int value) {
        score += value;
        scoreUpdatePending = false;
    }

}
