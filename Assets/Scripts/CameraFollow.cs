using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;
    public GameObject floor;

    public float offset;

    private Collider floorCollider;

    // Start is called before the first frame update
    void Start()
    {
        floorCollider = floor.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 floorPoint = floorCollider.ClosestPoint(ball.transform.position);
        Vector3 dirToFloor = (ball.transform.position - floorPoint).normalized;
        Debug.Log(floorPoint + ":::" + dirToFloor);
        Vector3 adjustedPos = ball.transform.position + (dirToFloor * -offset);

        transform.position = ball.transform.position + new Vector3(0, 10, -10);
    }
}
