using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PickupCoinTrigger : MonoBehaviour
{
    public GameObject gfx;
    public AudioSource sfx;

    public int rotSpeed;
    public int scoreValue = 1;

    private void Update()
    {
        transform.Rotate(0, rotSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            // Get global score and increment it
            GameManager gm = FindAnyObjectByType<GameManager>();
            if (gm != null)
            {
                gm.increaseScore(scoreValue);
            }
            // Play sfx then delete coin coin
            sfx.Play();
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }

            StartCoroutine(killSelfAfterNoise());
        }
    }

    IEnumerator killSelfAfterNoise()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
