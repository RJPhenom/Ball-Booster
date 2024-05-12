using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Plane for movement voodoo
    public GameObject planarVoodoo;
    private GameObject childVoodoo;

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

    // thruster visual
    Vector3 thrustDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
        origin = transform.position;

        thrusterVFX.SetActive(false);
        childVoodoo = planarVoodoo.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        // Transofrm handling
        ThrusterFollowBall();

        planarVoodoo.transform.LookAt(ball.transform.position);
    }

    // FixedUpdate is called on every physics tick
    void FixedUpdate()
    {
        thrustDir = Vector3.zero;

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
            ThrusterRotate();
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
        rb.AddForce(-childVoodoo.transform.forward * moveSpeed, ForceMode.VelocityChange);
        thrustDir += -childVoodoo.transform.forward;
    }

    void MoveBackward()
    {
        rb.AddForce(childVoodoo.transform.forward * moveSpeed, ForceMode.VelocityChange);
        thrustDir += childVoodoo.transform.forward;
    }

    void MoveLeft()
    {
        rb.AddForce(-childVoodoo.transform.right * moveSpeed, ForceMode.VelocityChange);
        thrustDir += -childVoodoo.transform.right;
    }

    void MoveRight()
    {
        rb.AddForce(childVoodoo.transform.right * moveSpeed, ForceMode.VelocityChange);
        thrustDir += childVoodoo.transform.right;
    }

    void ThrusterFollowBall()
    {
        transform.position = ball.transform.position;
    }

    void ThrusterRotate()
    {
        Quaternion newRot = Quaternion.LookRotation(thrustDir);
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

    float GetAngleofBallUpWall()
    {
        Vector3 downVec = Vector3.down;
        Vector3 ballVec = ball.transform.position;

        return Vector3.Angle(downVec, ballVec);
    }
}
