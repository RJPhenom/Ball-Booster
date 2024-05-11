using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    private int score;
    private bool scoreUpdated = true;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        // Get UI element and update text to reflect new score
        if (!scoreUpdated)
        {
            // Apply update to score
            Debug.Log("Score increased to " + score.ToString());
            scoreUpdated = true;
        }
    }

    public void increaseScore(int value) {
        score += value;
        scoreUpdated = false;
    }

}
