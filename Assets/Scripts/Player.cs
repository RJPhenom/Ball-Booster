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
            ThrusterRotate();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveBackward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
            ThrusterRotate();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
            ThrusterRotate();
        }
    }

    void MoveForward()
    {
        rb.AddForce(transform.forward * moveSpeed, ForceMode.VelocityChange);
        thrustDir.z = 1;
    }

    void MoveBackward()
    {
        rb.AddForce(-transform.forward * moveSpeed, ForceMode.VelocityChange);
        thrustDir.z = -1;
    }

    void MoveLeft()
    {
        rb.AddForce(-transform.right * moveSpeed, ForceMode.VelocityChange);
        thrustDir.x = -1;
    }

    void MoveRight()
    {
        rb.AddForce(transform.right * moveSpeed, ForceMode.VelocityChange);
        thrustDir.x = 1;
    }

    void ThrusterFollowBall()
    {
        transform.position = ball.transform.position;
    }

    void ThrusterRotate()
    {
        Quaternion newRot = Quaternion.LookRotation(rb.velocity);
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
        GameManager gm = FindAnyObjectByType<GameManager>();
        if (gm != null)
        {
            gm.ShowResults();
        }
    }
}
