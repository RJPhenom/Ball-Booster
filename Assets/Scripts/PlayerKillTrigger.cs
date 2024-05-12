using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillTrigger : MonoBehaviour
{
    public AudioSource sfx;

    private void OnTriggerEnter(Collider other)
    {
        // The player's ball collided
        if (other.gameObject.tag == "Player")
        {
            // Grab the player's thruster that contains its properties
            GameObject thruster = GameObject.Find("Thruster");
            if (thruster != null)
            {
                // Grab the player's properties to perform its common kill action
                Player props = thruster.GetComponent<Player>();
                if (props != null)
                {
                    sfx.Play();
                    props.KillPlayer();
                }
            }
        }
        else
        {
            Debug.Log("Thruster failed to be found!");
        }
    }
}
