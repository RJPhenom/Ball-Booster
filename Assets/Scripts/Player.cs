using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Members
    public GameObject ball;
    public float moveSpeed;
    public float rotSpeed;

    private Rigidbody rb;

    // Assets
    public GameObject thrusterVFX;
    public AudioSource thrusterSFX;

    // Startup Values
    private Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
        origin = transform.position;

        thrusterVFX.SetActive(false);
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
        bool inputActive = false;

        if (Input.GetKey(KeyCode.W))
        {
            inputActive = true;
            MoveForward();
            ThrusterRotate();
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputActive = true;
            MoveBackward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputActive = true;
            MoveLeft();
            ThrusterRotate();
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputActive = true;
            MoveRight();
            ThrusterRotate();
        }

        thrusterVFX.SetActive(inputActive);
        if (inputActive && !thrusterSFX.isPlaying)
        {
            thrusterSFX.Play();
        }

        else if (!inputActive)
        {
            thrusterSFX.Stop();
        }
    }

    void MoveForward()
    {
        rb.AddForce(transform.forward * moveSpeed, ForceMode.VelocityChange);
    }

    void MoveBackward()
    {
        rb.AddForce(-transform.forward * moveSpeed, ForceMode.VelocityChange);
        thrustDir.z = -1;
    }

    void MoveLeft()
    {
        rb.AddForce(-transform.right * moveSpeed, ForceMode.VelocityChange);
    }

    void MoveRight()
    {
        rb.AddForce(transform.right * moveSpeed, ForceMode.VelocityChange);
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
