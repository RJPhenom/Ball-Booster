using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject floor;
    SphereCollider floorCollider;
    float radius;

    public GameObject boostPickup;
    public GameObject boostPad;
    public GameObject jumpPad;
    public GameObject slowPit;
    public GameObject teslaWall;
    public GameObject coin;


    // Start is called before the first frame update
    void Start()
    {
        floorCollider = floor.GetComponent<SphereCollider>();
        radius = floorCollider.radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Spawn(boostPickup);
        }
    }

    void Spawn(GameObject obj)
    {
        GameObject spawned = Instantiate(obj);

        spawned.transform.position = randomPoint();
        rotateToMatchSphereFloor(spawned);
    }

    Vector3 randomPoint()
    {
        float x = Random.Range(-100, 100);
        float y = Random.Range(-100, 100);
        float z = Random.Range(-100, 100);

        Vector3 randomVec = new Vector3(x, y, z);
        Vector3 randomDir = (randomVec - Vector3.zero).normalized;
        Vector3 randPos = Vector3.zero + randomDir * radius;

        return randPos;
    }

    void rotateToMatchSphereFloor(GameObject obj)
    {
        Vector3 upDir = (Vector3.zero - obj.transform.position).normalized;
        Debug.LogWarning(upDir);

        Plane localPlane = new Plane(upDir, obj.transform.position);
        Vector3 planePoint = localPlane.ClosestPointOnPlane(randomPoint());

        Vector3 fwdDir = (planePoint - obj.transform.position).normalized;
        Debug.LogWarning(fwdDir);

        Quaternion rot = new Quaternion();
        rot.SetLookRotation(fwdDir, upDir);

        obj.transform.rotation = rot;
    }
}
