using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBoost : MonoBehaviour
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
        // 
        if (thruster != null)
        {
            Player stats = thruster.GetComponent<Player>();
            if (stats != null)
            {
                float baseSpeed = stats.moveSpeed;
                stats.moveSpeed *= multiplier;

                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Collider>().enabled = false;

                yield return new WaitForSeconds(duration);

                // Reset speed back to base if it has been increased
                if (stats.moveSpeed > baseSpeed)
                {
                    stats.moveSpeed = baseSpeed;
                }
            }
        }
        else
        {
            Debug.Log("Thruster failed to be found!");
        }
        Destroy(gameObject);
    }
}
