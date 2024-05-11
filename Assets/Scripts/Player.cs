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

    // Startup Values
    private Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
        origin = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        // Transofrm handling
        ThrusterFollowBall();
    }

    // FixedUpdate is called on every physics tick
    void FixedUpdate()
    {
        // Inputs
        HandleMovementInput();
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
    }

    void MoveBackward()
    {
        rb.AddForce(-Vector3.forward * moveSpeed, ForceMode.VelocityChange);
    }

    void MoveLeft()
    {
        rb.AddForce(-Vector3.right * moveSpeed, ForceMode.VelocityChange);
    }

    void MoveRight()
    {
        rb.AddForce(Vector3.right * moveSpeed, ForceMode.VelocityChange);
    }

    void ThrusterFollowBall()
    {
        Quaternion newRot = Quaternion.LookRotation(rb.velocity);

        transform.position = ball.transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, rotSpeed);
    }

    // Updates the Player's position back to its start position
    void ResetPosition()
    {
        ball.transform.position = origin;
        ThrusterFollowBall();
    }

    public void KillPlayer()
    {
        ResetPosition();
    }
}
