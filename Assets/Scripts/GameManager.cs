using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        // Get UI element and update text to reflect new score
    }

    public void increaseScore(int score) {
        score += score;
    }

}
