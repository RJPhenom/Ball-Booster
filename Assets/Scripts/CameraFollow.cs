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
        Vector3 dirToWorldZero = (ball.transform.position - Vector3.zero).normalized;

        transform.position = ball.transform.position + dirToWorldZero * offset;
    }
}
