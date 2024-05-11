using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTrigger : MonoBehaviour
{

    public float slowLimit = 0.25f;
    public float slowMagnitude = 0.375f;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            GameObject thruster = GameObject.Find("Thruster");
            if (thruster != null)
            {
                Player stats = thruster.GetComponent<Player>();
                if (stats != null)
                {
                    if (stats.moveSpeed > slowLimit)
                    {
                        stats.moveSpeed -= slowMagnitude;
                    }
                    else
                    {
                        stats.moveSpeed = slowLimit;
                    }
                }
            }
            else
            {
                Debug.Log("Thruster failed to be found!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject thruster = GameObject.Find("Thruster");
            if (thruster != null)
            {
                Player stats = thruster.GetComponent<Player>();
                if (stats != null)
                {
                    StartCoroutine( Accelerate(stats) );
                }
            }
            else
            {
                Debug.Log("Thruster failed to be found!");
            }
        }
    }

    IEnumerator Accelerate(Player player) {
        // Assume 1 is player base speed
        float playerBaseSpeed = 1;
        while (player.moveSpeed < playerBaseSpeed) {
            if (player.moveSpeed + slowMagnitude < playerBaseSpeed)
            {
                player.moveSpeed += player.moveSpeed + slowMagnitude;
            }
            else
            {
                player.moveSpeed = playerBaseSpeed;
            }

            yield return new WaitForSeconds(1);
        }
    }

}
