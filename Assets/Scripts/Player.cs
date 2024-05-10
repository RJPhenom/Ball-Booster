using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Members
    public GameObject ball;
    public float moveSpeed;
    public float rotSpeed;

    private Rigidbody rb;
    private Vector3 thrustDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Inputs
        HandleMovementInput();

        // Transofrm handling
        ThrusterFollowBall();
    }

    void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveBackward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
    }

    void MoveForward()
    {
        rb.AddForce(Vector3.forward * moveSpeed, ForceMode.VelocityChange);
        thrustDir.z = 1;
    }

    void MoveBackward()
    {
        rb.AddForce(-Vector3.forward * moveSpeed, ForceMode.VelocityChange);
        thrustDir.z = -1;
    }

    void MoveLeft()
    {
        rb.AddForce(-Vector3.right * moveSpeed, ForceMode.VelocityChange);
        thrustDir.x = -1;
    }

    void MoveRight()
    {
        rb.AddForce(Vector3.right * moveSpeed, ForceMode.VelocityChange);
        thrustDir.x = 1;
    }

    void ThrusterFollowBall()
    {
        Quaternion newRot = Quaternion.LookRotation(rb.velocity);
        
        transform.position = ball.transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, rotSpeed);
    }
}
