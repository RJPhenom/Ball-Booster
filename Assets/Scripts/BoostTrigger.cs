using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostTrigger : MonoBehaviour
{

    public float forceMultiplier = 5f;

    private Vector3 direction;

    private void Start()
    {
        direction = transform.forward;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") { 
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(direction * forceMultiplier, ForceMode.Impulse);
            }
        }
    }
}
