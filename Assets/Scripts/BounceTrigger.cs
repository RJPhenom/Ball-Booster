using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceTrigger : MonoBehaviour
{
    private float bounceMultiplier = 22f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddForce(Vector3.up * bounceMultiplier, ForceMode.Impulse);
            }
        }
    }
}
