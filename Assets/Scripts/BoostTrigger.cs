using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public float multiplier = 1.5f;
    public float duration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        // The player is the ball, but the thruster is manipulating it
        GameObject thruster = GameObject.Find("Thruster");
        Player stats = thruster.GetComponent<Player>();
        stats.moveSpeed *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.moveSpeed /= multiplier;

        Destroy(gameObject);
    }
}
