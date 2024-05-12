using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBoost : MonoBehaviour
{
    public float boostBonus = 1f;
    public float duration = 5f;

    public AudioSource sfx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            other.gameObject.transform.parent.GetComponentInChildren<Player>().moveSpeed += boostBonus;
            sfx.Play();
            StartCoroutine(killSelfAfterNoise());
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator killSelfAfterNoise()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
