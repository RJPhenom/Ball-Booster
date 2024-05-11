using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PickupCoinTrigger : MonoBehaviour
{

    public int scoreValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            // Get global score and increment it
            GameManager gm = FindAnyObjectByType<GameManager>();
            gm.increaseScore(scoreValue);
            // Delete coin
            Destroy(gameObject);
        }
    }
}
