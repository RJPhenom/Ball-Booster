using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get relative direction from ball to world zero (spherefloor center) and get adjusted camera pos
        Vector3 dirToWorldZero = (ball.transform.position - Vector3.zero).normalized;
        Vector3 adjustedPos = ball.transform.position + dirToWorldZero * -offset;

        // Add z offset & update
        transform.position = adjustedPos + Vector3.back * offset;
        transform.LookAt(ball.transform.position);
    }
}
